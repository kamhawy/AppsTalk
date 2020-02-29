using ABATS.AppsTalk.UX;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Collections.Generic;

namespace ABATS.AppsTalk
{
    /// <summary>
    /// Default
    /// </summary>
    public partial class Default : View
    {
        protected override void LoadView()
        {
            //ABATS.AppsTalk.Data.DBEntities ds = new Data.DBEntities();

            //System.Data.Objects.ObjectContext objCon =  (ds as IObjectContextAdapter).ObjectContext;

            //List<AppsTalk.Data.Application> apps = objCon.CreateObjectSet<AppsTalk.Data.Application>().ToList();
            //List<AppsTalk.Data.Application> apps2 = ds.Set<AppsTalk.Data.Application>().ToList();
            //List<AppsTalk.Data.Application> apps3 = base.AppRuntime.DataService.GetAll<AppsTalk.Data.Application>().ToList();

            base.LoadView();
        }
    }
}