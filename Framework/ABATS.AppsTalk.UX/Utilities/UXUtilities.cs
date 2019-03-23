using System.Collections.Generic;
using System.Web.UI;

namespace ABATS.AppsTalk.UX
{
    /// <summary>
    /// UX Utilities
    /// </summary>
    public static class UXUtilities
    {
        #region Controls

        /// <summary>
        /// Get Controls
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pControlCollection"></param>
        /// <param name="pRecursive"></param>
        /// <returns></returns>
        public static List<T> GetControls<T>(ControlCollection pControlCollection, bool pRecursive) where T : Control
        {
            List<T> listControls = null;

            try
            {
                listControls = new List<T>();

                foreach (Control cntrl in pControlCollection)
                {
                    if (cntrl is T)
                    {
                        listControls.Add(cntrl as T);
                    }

                    if (pRecursive)
                    {
                        List<T> childControls = UXUtilities.GetControls<T>(cntrl);

                        if (childControls.Count > 0)
                        {
                            listControls.AddRange(childControls);
                        }
                    }
                }
            }
            catch { throw; }

            return listControls;
        }

        /// <summary>
        /// Get Controls
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pControl"></param>
        /// <returns></returns>
        public static List<T> GetControls<T>(Control pControl) where T : Control
        {
            List<T> listControls = null;

            try
            {
                foreach (Control cntrl in pControl.Controls)
                {
                    if (cntrl is T)
                    {
                        listControls.Add(cntrl as T);
                    }

                    if (cntrl.Controls.Count > 0)
                    {
                        List<T> childControls = UXUtilities.GetControls<T>(cntrl);

                        if (childControls.Count > 0)
                        {
                            listControls.AddRange(childControls);
                        }
                    }
                }
            }
            catch { throw; }

            return listControls;
        }

        #endregion

        #region Misc

        /// <summary>
        /// Is DropDownList Has Value
        /// </summary>
        /// <param name="pDropDownList"></param>
        /// <returns></returns>
        public static bool IsDropDownListHasValue(System.Web.UI.WebControls.DropDownList pDropDownList)
        {
            bool hasValue = false;

            try
            {
                if (pDropDownList != null && !string.IsNullOrEmpty(pDropDownList.SelectedValue))
                {
                    int value = -1;

                    if (int.TryParse(pDropDownList.SelectedValue, out value) &&
                        value > 0)
                    {
                        hasValue = true;
                    }
                }
            }
            catch { throw; }

            return hasValue;
        }

        #endregion
    }
}