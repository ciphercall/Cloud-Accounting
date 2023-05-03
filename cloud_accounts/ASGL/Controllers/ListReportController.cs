using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASGL.Controllers;
using ASGL.Models;
using RazorPDF;

namespace ASGL.Controllers
{
    public class ListReportController : AppController
    {
        private GLDbContext db = new GLDbContext();

       

        //public ActionResult GetListOfParty()
        //{
        //    //var pdf = new PdfResult(null, "GetListOfParty");
        //    //return pdf;
        //    return View();
        //}


        //public ActionResult GetExpensesList()
        //{
        //    //var pdf = new PdfResult(null, "GetExpensesList");
        //    //return pdf;
        //    return View();
        //}

        public ActionResult Get_HeadOfAccounts_List()
        {
            //var pdf = new PdfResult(null, "Get_HeadOfAccounts_List");
            //return pdf;
            return View();
        }

        public ActionResult Get_ListofCostPool()
        {
            return View();
        }

    }
}
