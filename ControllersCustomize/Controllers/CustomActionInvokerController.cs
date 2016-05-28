using ControllersCustomize.Infrastructure.ActionInvokers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersCustomize.Controllers
{
    public class CustomActionInvokerController : Controller
    {
        //
        // GET: /CustomActionInvoker/

        public CustomActionInvokerController()
        {
            this.ActionInvoker = new CustomActionInvoker();
        }

    }
}
