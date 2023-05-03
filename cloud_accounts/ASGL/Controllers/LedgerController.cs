using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ASGL.Models;

namespace ASGL.Controllers
{
    public class LedgerController : AppController
    {
        private GLDbContext db = new GLDbContext();

        // GET: /PosLedger/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PageModel model)
        {
            //var pdf = new PdfResult(aCnfJobModel, "GetJOBRegister_JobTypeReport");
            //return pdf;

            TempData["POS_Ledger"] = model;
            if (model.FromDate > model.ToDate)
            {
                TempData["ErrorFromDateMessage"] = "Plese select correct 'From Date' field!";
                TempData["ErrorToDateMessage"] = "Plese select correct 'To Date' field!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("LedgerReport");
        }
        public ActionResult LedgerReport()
        {
            PageModel model = (PageModel)TempData["POS_Ledger"];
            return View(model);
        }


        public ActionResult CashBookIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CashBookIndex(PageModel model)
        {
            TempData["CashBook"] = model;


            if (model.FromDate > model.ToDate)
            {
                TempData["ErrorFromDateMessage"] = "Plese select correct 'From Date' field!";
                TempData["ErrorToDateMessage"] = "Plese select correct 'To Date' field!";
                return RedirectToAction("CashBookIndex");
            }

            return RedirectToAction("CashBookReport");
        }
        public ActionResult CashBookReport()
        {
            PageModel model = (PageModel)TempData["CashBook"];
            return View(model);
        }

        public ActionResult BankBookIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BankBookIndex(PageModel model)
        {
            TempData["BankBook"] = model;
            if (model.FromDate > model.ToDate)
            {
                TempData["ErrorFromDateMessage"] = "Plese select correct 'From Date' field!";
                TempData["ErrorToDateMessage"] = "Plese select correct 'To Date' field!";
                return RedirectToAction("BankBookIndex");
            }
            return RedirectToAction("BankBookReport");
        }
        public ActionResult BankBookReport()
        {
            PageModel model = (PageModel)TempData["BankBook"];
            return View(model);
        }
    }
}
