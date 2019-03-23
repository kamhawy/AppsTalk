using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Cache Manager
    /// </summary>
    public class CacheManager : SingletonBase<CacheManager>
    {
        #region Members

        private List<string> _Keys = null;
        private TimeSpan _CacheDuration = TimeSpan.FromHours(1);
        private static object syncObject = new object();

        #endregion

        #region Properties

        private TimeSpan CacheDuration
        {
            get 
            {
                return this._CacheDuration; 
            }
        }

        private List<string> Keys
        {
            get
            {
                if (this._Keys == null)
                {
                    this._Keys = new List<string>();
                }

                return this._Keys;
            }
        }

        #endregion

        #region Singleton

        private CacheManager()
        {

        }

        #endregion

        #region Methods

        public T GetAndCheck<T>(CacheItem Key, Func<T> GetItem)
        {
            return GetAndCheck<T>(Key.ToString(), GetItem);
        }

        public T GetAndCheck<T>(string Key, Func<T> GetItem)
        {
            if (HasKey(Key))
            {
                return Grab<T>(Key);
            }
            else
            {
                lock (syncObject)
                {
                    if (this.HasKey(Key))
                    {
                        return Grab<T>(Key);
                    }
                    else
                    {
                        T item = GetItem();
                        this.Insert<T>(Key, item, CacheItemPriority.Default);
                        return item;
                    }
                }
            }
        }

        private static T Grab<T>(string Key)
        {
            if (HttpContext.Current != null)
            {
                return (T)HttpContext.Current.Cache[Key];
            }
            else
            {
                return default(T);
            }
        }

        private bool HasKey(string Key)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Cache[Key] != null && Keys.Contains(Key);
            }
            else
            {
                return false;
            }
        }

        private void Insert<T>(string Key, T obj, CacheItemPriority priority)
        {
            if (!Keys.Contains(Key))
                Keys.Add(Key);

            DateTime expiration = DateTime.Now.Add(this.CacheDuration);

            if (HttpContext.Current != null)
            {
                HttpContext.Current.Cache.Add(Key, obj, null, expiration, TimeSpan.Zero, priority, null);
            }
        }

        public void ClearAll()
        {
            if (HttpContext.Current != null)
            {
                lock (syncObject)
                {
                    foreach (string key in Keys)
                    {
                        HttpContext.Current.Cache.Remove(key);
                    }

                    Keys.Clear();
                }
            }
        }

        public void Clear(string Key)
        {
            lock (syncObject)
            {
                if (Keys.Contains(Key))
                    Keys.Remove(Key);


                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Cache.Remove(Key);
                }
            }
        }

        #endregion
    }
}