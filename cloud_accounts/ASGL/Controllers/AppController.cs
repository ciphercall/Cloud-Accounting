﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASGL.Models;

namespace ASGL.Controllers
{
    public class AppController : Controller
    {
        //
        // GET: /App/
        GLDbContext db = new GLDbContext();

        public GLDbContext DataContext
        {
            get { return db; }
        }

        public AppController()
        {

        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
           
            try
            {
                var userid = Convert.ToInt64(Session["loggedUserID"]);
                var comid = Convert.ToInt64(Session["loggedCompID"]);

           
                ViewData["validUserForm"] = from c in db.AslRoleDbSet
                                       where (c.USERID == userid && c.COMPID == comid && c.STATUS == "A" && c.MENUTP=="F" && c.MODULEID=="01")
                                       select c;

                ViewData["validUserReports"] = from c in db.AslRoleDbSet
                                            where (c.USERID == userid && c.COMPID == comid && c.STATUS == "A" && c.MENUTP == "R" && c.MODULEID=="01")
                                            select c;

                ViewData["validBillingForm"] = (from c in db.AslRoleDbSet
                                            where (c.USERID == userid && c.COMPID == comid && c.STATUS == "A" && c.MENUTP == "F" && c.MODULEID == "02")
                                            select c).OrderBy(x=>x.SERIAL);

                ViewData["validBillingReports"] = (from c in db.AslRoleDbSet
                                               where (c.USERID == userid && c.COMPID == comid && c.STATUS == "A" && c.MENUTP == "R" && c.MODULEID == "02")
                                               select c).OrderBy(x=>x.SERIAL);

                ViewData["validPromotionForm"] = (from c in db.AslRoleDbSet
                                                  where (c.USERID == userid && c.COMPID == comid && c.STATUS == "A" && c.MENUTP == "F" && c.MODULEID == "03")
                                                  select c).OrderBy(x => x.SERIAL);

                var findCompanyName = from m in db.AslCompanyDbSet where m.COMPID == comid select new { m.COMPNM };
                string Name = "";
                foreach (var name in findCompanyName)
                {
                    ViewData["CompanyName"] = name.COMPNM;
                }

            }
            catch
            {

            }
        }

    }
}
