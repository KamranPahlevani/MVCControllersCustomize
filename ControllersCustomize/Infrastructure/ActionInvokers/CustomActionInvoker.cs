using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersCustomize.Infrastructure.ActionInvokers
{
    public class CustomActionInvoker:IActionInvoker
    {
        public bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (actionName == "index")
            {
                controllerContext.HttpContext.Response.Write("This is output from the index action");
                return true;
            }
            else
                return false;
        }
    }
}