using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Messages;

namespace NsbFront.Controllers
{
    public class SaySomethingController : AsyncController
    {
        public void IndexAsync()
        {
            MvcApplication.Bus.Send<RequestWithResponse>(m => m.SaySomething = "Said something from web. Ex")
                .Register<int>(response =>
                    {
                        AsyncManager.Parameters["response"] = response.ToString();
                    });
        }

       public ActionResult IndexCompleted(string response)
       {
           return Content("Request from server " + response);
       }
    }
}
