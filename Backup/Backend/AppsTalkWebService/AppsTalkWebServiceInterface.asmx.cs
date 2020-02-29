using System;
using System.Web.Services;
using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Runtime;

namespace AppsTalkWebService
{
    /// <summary>
    /// Summary description for AppsTalkWebServiceInterface
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class AppsTalkWebServiceInterface : System.Web.Services.WebService
    {
        [WebMethod]
        public LanuchIntegrationProcessResponse LanuchIntegrationProcessAsync(LanuchIntegrationProcessRequest pRequest)
        {
            LanuchIntegrationProcessResponse response = null;

            try
            {
                if (pRequest == null)
                {
                    throw new ArgumentNullException("Request can not be Null");
                }

                using (ExecutionManager exeManager = new ExecutionManager())
                {
                    exeManager.TryExecute(pRequest.Parameters);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return response;
        }
    }
}