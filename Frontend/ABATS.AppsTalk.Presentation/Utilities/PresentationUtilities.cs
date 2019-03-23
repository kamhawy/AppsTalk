using System.Web.UI;
using System.Web.UI.WebControls;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Presentation.Utilities
{
    /// <summary>
    /// Presentation Utilities
    /// </summary>
    public static class PresentationUtilities
    {
        #region Utilities

        /// <summary>
        /// Get Form View Control
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pFormView"></param>
        /// <param name="pControlName"></param>
        /// <returns></returns>
        public static T GetFormViewControl<T>(FormView pFormView, string pControlName) where T : Control
        {
            T cntrl = pFormView.FindControl(pControlName) as T;

            return cntrl;
        }

        /// <summary>
        /// GetPriceGridColumnFormat
        /// </summary>
        /// <param name="pDecimalDigits"></param>
        /// <returns></returns>
        public static string GetGridColumnFormat(int pDecimalDigits)
        {
            string format = "{0:########";

            if (pDecimalDigits > 0) { format += "."; }

            for (int i = 1; i <= pDecimalDigits; i++)
            {
                format += "0";
            }

            format += "}";

            return format;
        }

        /// <summary>
        /// Can Add Or Edit
        /// </summary>
        /// <param name="pUIMode"></param>
        /// <returns></returns>
        public static bool CanAddOrEdit(UIMode pUIMode)
        {
            bool canAddOrEdit = false;

            try
            {
                switch (pUIMode)
                {
                    case UIMode.View:
                        {
                            canAddOrEdit = false;
                        }
                        break;
                    case UIMode.Add:
                        {
                            canAddOrEdit = true;
                        }
                        break;
                    case UIMode.Edit:
                        {
                            canAddOrEdit = true;
                        }
                        break;
                    case UIMode.Admin:
                        {
                            canAddOrEdit = true;
                        }
                        break;
                    default:
                        { }
                        break;
                }

            }
            catch { throw; }

            return canAddOrEdit;
        }

        /// <summary>
        /// Get End Point Type Image
        /// </summary>
        /// <param name="pEndPointType"></param>
        /// <returns></returns>
        public static string GetEndPointTypeImage(EndPointType pEndPointType)
        {
            string imageURL = string.Empty;

            switch (pEndPointType)
            {
                case EndPointType.None:
                case EndPointType.Database:
                    {
                        imageURL = "~/Contents/Images/database_128.png";
                    }
                    break;
                case EndPointType.WebService:
                    {
                        imageURL = "~/Contents/Images/webservice_256.png";
                    }
                    break;
                default:
                    break;
            }

            return imageURL;

        }

        #endregion
    }
}