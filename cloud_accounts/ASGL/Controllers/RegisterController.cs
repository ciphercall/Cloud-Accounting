using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASGL.Models;

namespace ASGL.Controllers
{
    public class RegisterController : AppController
    {
        //
        // GET: /Register/

        public ActionResult ChequeRegisterIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChequeRegisterIndex(PageModel model)
        {


            TempData["ChequeRegister"] = model;
            if (model.FromDate > model.ToDate)
            {
                TempData["ErrorFromDateMessage"] = "Plese select correct 'From Date' field!";
                TempData["ErrorToDateMessage"] = "Plese select correct 'To Date' field!";
                return RedirectToAction("ChequeRegisterIndex");
            }
            return RedirectToAction("ChequeRegisterReport");
        }
        public ActionResult ChequeRegisterReport()
        {
            PageModel model = (PageModel)TempData["ChequeRegister"];
            return View(model);
        }



        public ActionResult JournalRegisterIndex()
        {
            return View();
        }

    }
}
