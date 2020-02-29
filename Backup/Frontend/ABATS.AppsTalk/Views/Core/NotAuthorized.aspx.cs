using ABATS.AppsTalk.UX;

namespace ABATS.AppsTalk.Views.Core
{
    /// <summary>
    /// Not-Authorized
    /// </summary>
    public partial class NotAuthorized : View
    {
        #region Overrides

        public override bool NeedsAuthorization
        {
            get
            {
                return false;
            }
        }

        #endregion
    }
}