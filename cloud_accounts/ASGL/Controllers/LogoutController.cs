using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASGL.Controllers
{
    public class LogoutController : Controller
    {
        public ActionResult Index()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
