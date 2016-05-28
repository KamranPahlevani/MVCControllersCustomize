using ControllersCustomize.Infrastructure.ActionInvokers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersCustomize.Controllers
{
    public class ActionMethodSelectorController : Controller
    {
        //
        // GET: /Default/

        [ActionName("Index")]
        public ActionResult FirstMethod()
        {
            return View((object)"Message from FirstMethod");
        }

        [Local]
        [ActionName("Index")]
        public ActionResult SecondMethod()
        {
            return View((object)"Message from SecondMethod");
        }

        protected override void HandleUnknownAction(string actionName)
        {
            Response.Write("request for " + actionName + " is invalid");
        }

    }
}
