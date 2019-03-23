using System.Reflection;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Represent the base abstract class any Singleton class in the application,
    /// this base class eleminate the duplication of implementing the Singleton design pattern
    /// </summary>
    /// <typeparam name="T">Type of the class</typeparam>
    public abstract class SingletonBase<T> : DisposableBase where T : class
    {
        #region Members

        /// <summary>
        /// Instance Member
        /// </summary>
        private static T _Instance = null;

        /// <summary>
        /// Lock Object
        /// </summary>
        private static readonly object _lockObj = new object();

        /// <summary>
        /// Is Created
        /// </summary>
        private static bool _IsCreated = false;

        #endregion

        #region Properties

        /// <summary>
        /// Singleton Instance
        /// </summary>
        public static T Instance
        {
            get
            {
                lock (_lockObj)
                {
                    if (_Instance == null)
                    {
                        _Instance = typeof(T).InvokeMember(typeof(T).Name,
                                                           BindingFlags.CreateInstance |
                                                           BindingFlags.Instance |
                                                           BindingFlags.Public |
                                                           BindingFlags.NonPublic,
                                                           null, null, null, System.Globalization.CultureInfo.CurrentCulture) as T;

                        SingletonBase<T>.IsCreated = true;
                    }

                    return _Instance;
                }
            }
        }

        /// <summary>
        /// Is Created
        /// </summary>
        public static bool IsCreated
        {
            get
            {
                return SingletonBase<T>._IsCreated;
            }
            private set
            {
                SingletonBase<T>._IsCreated = value;
            }
        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            base.DisposeManagedRessources();
        }

        #endregion
    }
}