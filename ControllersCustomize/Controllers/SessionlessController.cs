using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace ControllersCustomize.Controllers
{
    ///if use DefaultControllerFactory with this attribute access to SessionState for Current Controller
    //[SessionState(SessionStateBehavior.Disabled)]
    public class SessionlessController : Controller
    {
        //
        // GET: /Sessionless/

        public ContentResult Index()
        {
            try
            {
                Session["Message"] = 1;
                return Content("Success");
            }
            catch (Exception ex)
            {
                return Content("Session Use is not permitted");
            }
        }

    }
}
