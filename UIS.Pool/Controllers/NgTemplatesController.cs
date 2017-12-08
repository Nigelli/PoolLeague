using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using log4net;
using UIS.Pool.Controllers;

namespace MMP.Web.Common.Controllers
{
    public class NgTemplatesController: Controller
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(PoolApiController));

        private bool ViewExists(string name)
        {
            ViewEngineResult result = ViewEngines.Engines.FindView(ControllerContext, name, null);
            return (result.View != null);
        }

        [AllowAnonymous]
        [Route("NgTemplates")]
        [Route("NgTemplates/{ViewName?}")]
        public ActionResult GetTemplate()
        {
            try
            {
                var request = Request;
                string ViewName = request.QueryString["ViewName"] ?? null;
                if (ViewName != null && ViewExists(ViewName))
                {
                    return View(ViewName);
                }
                throw new HttpException(404, $"View Not Found: {ViewName}");
            }
            catch (Exception ex)
            {
                logger.Warn($"Requested View not found", ex);
                throw;
            }

        }
    }
}
