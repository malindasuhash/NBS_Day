using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Messages;

namespace NsbFront.Controllers
{
    public class SaySomethingController : Controller
    {
        public ActionResult Index()
        {
            MvcApplication.Bus.Send<Request>(m => m.SaySomething = "Said something from web.");

            return Content("Message sent!");
        }
    }
}
