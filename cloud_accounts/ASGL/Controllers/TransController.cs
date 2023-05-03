using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASGL.Models;

namespace ASGL.Controllers
{
    public class TransController : AppController
    {
        
        // GET: /PosTrans/

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

            return RedirectToAction("TransReport");
        }
        public ActionResult TransReport()
        {
            PageModel model = (PageModel)TempData["POS_Ledger"];
            return View(model);
        }

    }
}
