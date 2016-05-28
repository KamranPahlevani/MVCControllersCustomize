using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace ControllersCustomize.Infrastructure
{
    public class RemoteService
    {
        public string GetRemoteData()
        {
            Thread.Sleep(10000);
            return "Hello from ther side of the world";
        }
    }
}