using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASGL.Models;

namespace ASGL.Controllers
{
    public class IncomeController : AppController
    {
        //
        // GET: /Income/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PageModel model)
        {
            TempData["Income Statement"] = model;
            if (model.FromDate > model.ToDate)
            {
                TempData["ErrorFromDateMessage"] = "Plese select correct 'From Date' field!";
                TempData["ErrorToDateMessage"] = "Plese select correct 'To Date' field!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("IncomeStatementReport");
        }

        public ActionResult IncomeStatementReport()
        {

            PageModel model = (PageModel)TempData["Income Statement"];
            return View(model);
        }
    }
}
