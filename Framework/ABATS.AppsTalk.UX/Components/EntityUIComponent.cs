using System;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.UX
{
    /// <summary>
    /// Entity UIComponent
    /// </summary>
    public abstract class EntityUIComponent<T, P> : UIComponent<P>
        where T : DBEntityBase
        where P : EntityPresenterBase<T>
    {
        #region Constructors

        public EntityUIComponent()
            : base()
        {

        }

        #endregion

        #region Overrides

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.IsPostBack)
            {
                this.InitializeEntity();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize Entity
        /// </summary>
        protected void InitializeEntity()
        {
            try
            {
                if (base.Presenter != null)
                {
                    base.Presenter.LoadCurrentEntity();

                    if (base.Presenter.CurrentUIMode != UIMode.Add && base.Presenter.Entity != null)
                    {
                        LoadEntityInfo(this.Presenter.Entity);
                    }

                    AdjustEntityUX(base.Presenter.Entity, base.Presenter.CurrentUIMode);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }
        }

        /// <summary>
        /// Load Entity Info
        /// </summary>
        /// <param name="pEntity"></param>
        protected virtual void LoadEntityInfo(T pEntity)
        {

        }

        /// <summary>
        /// Adjust Entity UX
        /// </summary>
        /// <param name="pEntity"></param>
        /// <param name="pUIMode"></param>
        protected virtual void AdjustEntityUX(T pEntity, UIMode pUIMode)
        {

        }

        #endregion
    }
}