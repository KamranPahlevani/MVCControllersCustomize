using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersCustomize.Controllers
{
    public class RestServiceController : Controller
    {
        //
        // GET: /RestService/

        [HttpGet]
        [ActionName("Rest")]
        public ActionResult GetRestAction()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Rest")]
        public ActionResult ModufyRestAction()
        {
            return View();
        }

        [HttpDelete]
        [ActionName("Rest")]
        public ActionResult DeleteRestAction()
        {
            return View();
        }

    }
}
