using System;
using System.Runtime.CompilerServices;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// DisposableBase
    /// </summary>
    [Serializable]
    public abstract class DisposableBase : IDisposable
    {
        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableBase"/> class.
        /// </summary>
        public DisposableBase()
        {

        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="DisposableBase"/> is reclaimed by garbage collection.
        /// </summary>
        ~DisposableBase()
        {
            Dispose(false);
        }

        #endregion

        #region IDisposable

        private bool m_IsDisposed = false;

        /// <summary>
        /// Used to free all the used resources
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (m_IsDisposed == false)
            {
                if (disposing)
                {
                    DisposeManagedRessources();
                }

                DisposeUnmanagedRessources();

                m_IsDisposed = true;
            }
        }

        #endregion

        #region Virtual Methods

        /// <summary>
        /// Dispose Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected virtual void DisposeManagedRessources()
        {

        }

        /// <summary>
        /// Free Unmanaged Ressources
        /// </summary>
        protected virtual void DisposeUnmanagedRessources()
        {

        }

        #endregion
    }
}