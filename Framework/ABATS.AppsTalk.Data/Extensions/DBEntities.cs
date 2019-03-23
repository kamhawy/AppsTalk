using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    /// <summary>
    /// DBEntities - Extension
    /// </summary>
    public partial class DBEntities
    {
        #region Overrides

        protected override void Dispose(bool disposing)
        {
            EFManager.Instance.RemoveDbContext(WebUtilities.GetCurrentUserName());
            //base.Dispose(disposing);
        }

        #endregion
    }
}