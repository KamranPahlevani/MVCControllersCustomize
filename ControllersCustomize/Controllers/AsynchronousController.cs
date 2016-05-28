using ControllersCustomize.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ControllersCustomize.Controllers
{
    public class AsynchronousController : AsyncController
    {
        //
        // GET: /Asynchronous/

        /// <summary>
        /// Task Model
        /// </summary>
        [NoAsyncTimeout]
        public void TaskDataAsync()
        {
            AsyncManager.OutstandingOperations.Increment();

            Task.Factory.StartNew(() =>
            {
                //create the model object
                RemoteService service = new RemoteService();
                //call the IO-bound time-consuming function
                string data = service.GetRemoteData();

                AsyncManager.Parameters["data"] = data;
                AsyncManager.OutstandingOperations.Decrement();
            });
        }

        public ActionResult TaskDataCompleted(string data)
        {
            return View((object)data);
        }

        /// <summary>
        /// APM Model
        /// </summary>
        [NoAsyncTimeout]
        public void APMDataPageAsync()
        {
            AsyncManager.OutstandingOperations.Increment();

            WebRequest req = WebRequest.Create("http://asp.net");

            req.BeginGetResponse((IAsyncResult ias) =>
            {
                WebResponse resp = req.EndGetResponse(ias);

                string content = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                AsyncManager.Parameters["html"] = content;
                AsyncManager.OutstandingOperations.Decrement();
            }, null);           
        }

        public ContentResult APMDataPageCompleted(string html)
        {
            return Content(html, "text/html");
        }
    }
}
