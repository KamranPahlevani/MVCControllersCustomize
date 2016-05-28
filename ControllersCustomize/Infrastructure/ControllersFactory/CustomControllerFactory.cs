using ControllersCustomize.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace ControllersCustomize.Infrastructure.ControllersFactory
{
    public class CustomControllerFactory:IControllerFactory
    {
        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            Type targetType = null;
            switch (controllerName.ToLower())
            {
                case "home":
                    requestContext.RouteData.Values["controller"] = "First";
                    targetType = typeof(FirstController);
                    break;
                case "first":
                    targetType = typeof(FirstController);
                    break;
                case "second":
                    targetType = typeof(SecondController);
                    break;
                case "customactioninvoker":
                    targetType = typeof(CustomActionInvokerController);
                    break;
                case "actionmethodselector":
                    targetType = typeof(ActionMethodSelectorController);
                    break;
                case "sessionless":
                    targetType = typeof(SessionlessController);
                    break;
                case "asynchronous":
                    targetType = typeof(AsynchronousController);
                    break;
                case "restservice":
                    targetType = typeof(RestServiceController);
                    break;
            }
            return targetType == null ? null : (IController)Activator.CreateInstance(targetType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            SessionStateBehavior SSB = SessionStateBehavior.Default;
            switch (controllerName.ToLower())
            {
                case "sessionless":
                    SSB = SessionStateBehavior.Disabled;
                    break;
                default:
                    SSB = SessionStateBehavior.Default;
                    break;
            }
            return SSB;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}