using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASGL.Models;

namespace ASGL.Controllers
{
    public class AccountHeadController : AppController
    {
        //Datetime formet
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
        TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
        public DateTime td;


        GLDbContext db = new GLDbContext();
        //Get Ip ADDRESS,Time & user PC Name
        public string strHostName;
        public IPHostEntry ipHostInfo;
        public IPAddress ipAddress;

        public AccountHeadController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            //td = DateTime.Now;
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        }




        // Create ASL_LOG object and it used to this Insert_Gl_ACCHARTMST_LogData, Update_Gl_ACCHARTMST_LogData, Delete_Gl_ACCHARTMST_LogData (GL_ACCHARTMST posHeadmst).
        public ASL_LOG aslLog = new ASL_LOG();

        // SAVE ALL INFORMATION from AccountHeadModel TO Asl_lOG Database Table.
        public void Insert_Headmst_LogData(AccountHeadModel aAccountItemModel)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("d"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslLogDbSet where n.COMPID == aAccountItemModel.GLACCHARMSTModel.COMPID && n.USERID == aAccountItemModel.GLACCHARMSTModel.INSUSERID select n.LOGSLNO).Max());
            if (maxSerialNo == 0)
            {
                aslLog.LOGSLNO = Convert.ToInt64("1");
            }
            else
            {
                aslLog.LOGSLNO = maxSerialNo + 1;
            }

            aslLog.COMPID = Convert.ToInt64(aAccountItemModel.GLACCHARMSTModel.COMPID);
            aslLog.USERID = aAccountItemModel.GLACCHARMSTModel.INSUSERID;
            aslLog.LOGTYPE = "INSERT";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = aAccountItemModel.GLACCHARMSTModel.INSIPNO;
            aslLog.LOGLTUDE = aAccountItemModel.GLACCHARMSTModel.INSLTUDE;
            aslLog.TABLEID = "GL_ACCHARMST";
            aslLog.LOGDATA = Convert.ToString("Head Code: " + aAccountItemModel.GLACCHARMSTModel.HEADCD + ",\nHead Name: " + aAccountItemModel.GLACCHARMSTModel.HEADNM + ",\nRemarks: " + aAccountItemModel.GLACCHARMSTModel.REMARKS + ".");
            aslLog.USERPC = aAccountItemModel.GLACCHARMSTModel.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }

        // Edit ALL INFORMATION from GL_ACCHARTMST TO Asl_lOG Database Table.
        public void Update_POSHeadmst_LogData(GL_ACCHARMST posHeadmst)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("d"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));


            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslLogDbSet where n.COMPID == posHeadmst.COMPID && n.USERID == posHeadmst.UPDUSERID select n.LOGSLNO).Max());
            if (maxSerialNo == 0)
            {
                aslLog.LOGSLNO = Convert.ToInt64("1");
            }
            else
            {
                aslLog.LOGSLNO = maxSerialNo + 1;
            }

            aslLog.COMPID = Convert.ToInt64(posHeadmst.COMPID);
            aslLog.USERID = posHeadmst.UPDUSERID;
            aslLog.LOGTYPE = "UPDATE";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = posHeadmst.UPDIPNO;
            aslLog.LOGLTUDE = posHeadmst.UPDLTUDE;
            aslLog.TABLEID = "GL_ACCHARMST";
            aslLog.LOGDATA = Convert.ToString("Head Code: " + posHeadmst.HEADCD + ",\nHead Name: " + posHeadmst.HEADNM + ",\nRemarks: " + posHeadmst.REMARKS + ".");
            aslLog.USERPC = posHeadmst.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }


        // Delete ALL INFORMATION from GL_ACCHARTMST TO Asl_lOG Database Table.
        public void Delete_POSHeadmst_LogData(GL_ACCHARMST posHeadmst)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("d"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslLogDbSet where n.COMPID == posHeadmst.COMPID && n.USERID == posHeadmst.UPDUSERID select n.LOGSLNO).Max());
            if (maxSerialNo == 0)
            {
                aslLog.LOGSLNO = Convert.ToInt64("1");
            }
            else
            {
                aslLog.LOGSLNO = maxSerialNo + 1;
            }

            aslLog.COMPID = Convert.ToInt64(posHeadmst.COMPID);
            aslLog.USERID = posHeadmst.UPDUSERID;
            aslLog.LOGTYPE = "DELETE";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = posHeadmst.UPDIPNO;
            aslLog.LOGLTUDE = posHeadmst.UPDLTUDE;
            aslLog.TABLEID = "GL_ACCHARMST";
            aslLog.LOGDATA = Convert.ToString("Head Code: " + posHeadmst.HEADCD + ",\nHead Name: " + posHeadmst.HEADNM + ",\nRemarks: " + posHeadmst.REMARKS + ".");
            aslLog.USERPC = posHeadmst.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }



        //  SAVE ALL INFORMATION from GL_ACCHART TO Asl_lOG Database Table.
        public void Insert_ACCHART_LogData(GL_ACCHART AccountItem)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("d"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslLogDbSet where n.COMPID == AccountItem.COMPID && n.USERID == AccountItem.INSUSERID select n.LOGSLNO).Max());
            if (maxSerialNo == 0)
            {
                aslLog.LOGSLNO = Convert.ToInt64("1");
            }
            else
            {
                aslLog.LOGSLNO = maxSerialNo + 1;
            }

            aslLog.COMPID = Convert.ToInt64(AccountItem.COMPID);
            aslLog.USERID = AccountItem.INSUSERID;
            aslLog.LOGTYPE = "INSERT";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = AccountItem.INSIPNO;
            aslLog.LOGLTUDE = AccountItem.INSLTUDE;
            aslLog.TABLEID = "GL_ACCHART";
            aslLog.LOGDATA = Convert.ToString("Head Code: " + AccountItem.HEADCD + ",\nAccount ID: " + AccountItem.ACCOUNTCD + ",\nAccount Type:" + AccountItem.HEADTP + ",\nAccount Name: " + AccountItem.ACCOUNTNM + ",\nRemarks: " + AccountItem.REMARKS + ".");
            aslLog.USERPC = AccountItem.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }


        // Edit ALL INFORMATION from GL_ACCHART TO Asl_lOG Database Table.
        public void Update_GL_ACCHART_LogData(ASL_LOG aslLOGRef)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("d"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslLogDbSet where n.COMPID == aslLOGRef.COMPID && n.USERID == aslLOGRef.USERID select n.LOGSLNO).Max());
            if (maxSerialNo == 0)
            {
                aslLog.LOGSLNO = Convert.ToInt64("1");
            }
            else
            {
                aslLog.LOGSLNO = maxSerialNo + 1;
            }


            aslLog.COMPID = Convert.ToInt64(aslLOGRef.COMPID);
            aslLog.USERID = aslLOGRef.USERID;
            aslLog.LOGTYPE = "UPDATE";
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = aslLOGRef.LOGIPNO;
            aslLog.LOGLTUDE = aslLOGRef.LOGLTUDE;
            aslLog.TABLEID = "GL_ACCHART";
            aslLog.LOGDATA = aslLOGRef.LOGDATA;
            aslLog.USERPC = strHostName;
            db.AslLogDbSet.Add(aslLog);
        }


        // Delete ALL INFORMATION from GL_ACCHART TO Asl_lOG Database Table.
        public void Delete_GL_ACCHART_LogData(GL_ACCHART AccountItem)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("d"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));


            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslLogDbSet where n.COMPID == AccountItem.COMPID && n.USERID == AccountItem.UPDUSERID select n.LOGSLNO).Max());
            if (maxSerialNo == 0)
            {
                aslLog.LOGSLNO = Convert.ToInt64("1");
            }
            else
            {
                aslLog.LOGSLNO = maxSerialNo + 1;
            }

            aslLog.COMPID = Convert.ToInt64(AccountItem.COMPID);
            aslLog.USERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
            aslLog.LOGTYPE = "DELETE";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = AccountItem.UPDIPNO;
            aslLog.LOGLTUDE = AccountItem.UPDLTUDE;
            aslLog.TABLEID = "GL_ACCHART";
            aslLog.LOGDATA = Convert.ToString("Head ID: " + AccountItem.HEADCD + ",\nAccount ID: " + AccountItem.ACCOUNTCD + ",\nAccount Name: " + AccountItem.ACCOUNTNM + ",\nAccount Type: " + AccountItem.HEADTP + ",\nRemarks: " + AccountItem.REMARKS + ".");
            aslLog.USERPC = AccountItem.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }




        // Create ASL_DELETE object and it used to this Delete_ASL_DELETE (AslUserco aslUsercos).
        public ASL_DELETE AslDelete = new ASL_DELETE();

        // Delete ALL INFORMATION from GL_ACCHARMST TO ASL_DELETE Database Table.
        public void Delete_ASL_DELETE_POS_HEADMST(GL_ACCHARMST posHeadmst)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("d"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslDeleteDbSet where n.COMPID == posHeadmst.COMPID && n.USERID == posHeadmst.UPDUSERID select n.DELSLNO).Max());
            if (maxSerialNo == 0)
            {
                AslDelete.DELSLNO = Convert.ToInt64("1");
            }
            else
            {
                AslDelete.DELSLNO = maxSerialNo + 1;
            }

            AslDelete.COMPID = Convert.ToInt64(posHeadmst.COMPID);
            AslDelete.USERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
            AslDelete.DELSLNO = AslDelete.DELSLNO;
            AslDelete.DELDATE = Convert.ToString(date);
            AslDelete.DELTIME = Convert.ToString(time);
            AslDelete.DELIPNO = posHeadmst.UPDIPNO;
            AslDelete.DELLTUDE = posHeadmst.UPDLTUDE;
            AslDelete.TABLEID = "GL_ACCHARMST";
            AslDelete.DELDATA = Convert.ToString("Head Code: " + posHeadmst.HEADCD + ",\nHead Name: " + posHeadmst.HEADNM + ",\nRemarks: " + posHeadmst.REMARKS + ".");
            AslDelete.USERPC = posHeadmst.USERPC;
            db.AslDeleteDbSet.Add(AslDelete);
        }


        // Delete ALL INFORMATION from GL_ACCHART TO ASL_DELETE Database Table.
        public void Delete_ASL_DELETE_ACCHART(GL_ACCHART AccountItem)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("d"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));


            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslDeleteDbSet where n.COMPID == AccountItem.COMPID && n.USERID == AccountItem.UPDUSERID select n.DELSLNO).Max());
            if (maxSerialNo == 0)
            {
                AslDelete.DELSLNO = Convert.ToInt64("1");
            }
            else
            {
                AslDelete.DELSLNO = maxSerialNo + 1;
            }

            AslDelete.COMPID = Convert.ToInt64(AccountItem.COMPID);
            AslDelete.USERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
            AslDelete.DELSLNO = AslDelete.DELSLNO;
            AslDelete.DELDATE = Convert.ToString(date);
            AslDelete.DELTIME = Convert.ToString(time);
            AslDelete.DELIPNO = AccountItem.UPDIPNO;
            AslDelete.DELLTUDE = AccountItem.UPDLTUDE;
            AslDelete.TABLEID = "GL_ACCHART";
            AslDelete.DELDATA = Convert.ToString("Head ID: " + AccountItem.HEADCD + ",\nAccount ID: " + AccountItem.ACCOUNTCD + ",\nAccount Type: " + AccountItem.HEADTP + ",\nAccount Name: " + AccountItem.ACCOUNTNM + ",\nRemarks: " + AccountItem.REMARKS + ".");
            AslDelete.USERPC = AccountItem.USERPC;
            db.AslDeleteDbSet.Add(AslDelete);
        }





        // GET: /Head/
        [AcceptVerbs("GET")]
        [ActionName("Index")]
        public ActionResult Index()
        {
            var dt = (AccountHeadModel)TempData["AccountHead"];
            return View(dt);
        }



        [AcceptVerbs("POST")]
        [ActionName("Index")]
        public ActionResult IndexPost(AccountHeadModel aAccountHeadModel, string command)
        {
            if (command == "Add")
            {
                //.........................................................Create Permission Check
                var LoggedCompId = System.Web.HttpContext.Current.Session["loggedCompID"].ToString();
                var loggedUserID = System.Web.HttpContext.Current.Session["loggedUserID"].ToString();

                var createStatus = "";

                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GLDbContext"].ToString());
                string query = string.Format("SELECT STATUS, INSERTR, UPDATER, DELETER FROM ASL_ROLE WHERE  CONTROLLERNAME='AccountHead' AND COMPID='{0}' AND USERID = '{1}'", LoggedCompId, loggedUserID);
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);

                foreach (DataRow row in ds.Rows)
                {
                    createStatus = row["INSERTR"].ToString();
                }

                conn.Close();

                if (createStatus == 'I'.ToString())
                {
                    TempData["ShowAddButton"] = "Show Add Button";
                    TempData["AccountHead"] = aAccountHeadModel;
                    TempData["HeadCD"] = aAccountHeadModel.GLACCHARMSTModel.HEADCD;
                    TempData["HeadTP"] = aAccountHeadModel.GLACCHARMSTModel.HEADTP;
                    TempData["message"] = "Permission not granted!";
                    return RedirectToAction("Index");
                }
                //...............................................................................................
                aAccountHeadModel.GLACCHARMSTModel.HEADTP = aAccountHeadModel.HEADTP;
                aAccountHeadModel.AcchartModel.COMPID = aAccountHeadModel.GLACCHARMSTModel.COMPID;
                aAccountHeadModel.AcchartModel.HEADCD = aAccountHeadModel.GLACCHARMSTModel.HEADCD;

                if (aAccountHeadModel.GLACCHARMSTModel.HEADCD == null)
                {
                    TempData["message"] = "Enter Head First";
                    return View("Index");
                }
                aAccountHeadModel.AcchartModel.USERPC = strHostName;
                aAccountHeadModel.AcchartModel.INSIPNO = ipAddress.ToString();
                aAccountHeadModel.AcchartModel.INSTIME = td;
                aAccountHeadModel.AcchartModel.INSUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                aAccountHeadModel.AcchartModel.INSLTUDE = aAccountHeadModel.GLACCHARMSTModel.INSLTUDE;


                try
                {


                    GL_ACCHARMST mstAccharmst_CompID = db.GlAccharmstDbSet.FirstOrDefault(r => (r.COMPID == aAccountHeadModel.GLACCHARMSTModel.COMPID));
                    Int64 HeadCode = Convert.ToInt64(aAccountHeadModel.GLACCHARMSTModel.HEADCD);
                    GL_ACCHARMST mstAccharmst_HeadCode = db.GlAccharmstDbSet.FirstOrDefault(r => (r.HEADCD == HeadCode));

                    if (mstAccharmst_CompID == null && mstAccharmst_HeadCode == null)
                    {
                        TempData["ShowAddButton"] = "Show Add Button";
                        TempData["message"] = "Head Code not found ";
                        return View("Index");
                    }
                    else
                    {
                        Int64 maxData = Convert.ToInt64((from n in db.GlAcchartDbSet where n.COMPID == aAccountHeadModel.GLACCHARMSTModel.COMPID && n.HEADCD == aAccountHeadModel.GLACCHARMSTModel.HEADCD select n.ACCOUNTCD).Max());

                        Int64 R = Convert.ToInt64(HeadCode + "9999");

                        if (maxData == 0)
                        {
                            aAccountHeadModel.AcchartModel.ACCOUNTCD = Convert.ToInt64(HeadCode + "0001");
                            aAccountHeadModel.AcchartModel.HEADTP = aAccountHeadModel.GLACCHARMSTModel.HEADTP;
                            Insert_ACCHART_LogData(aAccountHeadModel.AcchartModel);

                            db.GlAcchartDbSet.Add(aAccountHeadModel.AcchartModel);
                            if (db.SaveChanges() > 0)
                            {
                                TempData["message"] = "Account Successfully Saved";
                                aAccountHeadModel.AcchartModel.ACCOUNTNM = "";

                                aAccountHeadModel.AcchartModel.REMARKS = "";



                            }

                        }
                        else if (maxData <= R)
                        {

                            aAccountHeadModel.AcchartModel.ACCOUNTCD = maxData + 1;
                            aAccountHeadModel.AcchartModel.HEADTP = aAccountHeadModel.GLACCHARMSTModel.HEADTP;
                            Insert_ACCHART_LogData(aAccountHeadModel.AcchartModel);

                            db.GlAcchartDbSet.Add(aAccountHeadModel.AcchartModel);
                            db.SaveChanges();
                            TempData["message"] = "Account Successfully Saved";
                            aAccountHeadModel.AcchartModel.ACCOUNTNM = "";

                            aAccountHeadModel.AcchartModel.REMARKS = "";


                        }
                        else
                        {
                            TempData["message"] = "Account entry not possible";
                            TempData["ShowAddButton"] = "Show Add Button";

                        }
                    }


                }
                catch (Exception ex)
                {

                }
                TempData["ShowAddButton"] = "Show Add Button";
                TempData["AccountHead"] = aAccountHeadModel;
                TempData["HeadCD"] = aAccountHeadModel.GLACCHARMSTModel.HEADCD;
                TempData["HeadTP"] = aAccountHeadModel.GLACCHARMSTModel.HEADTP;
                return RedirectToAction("Index");
            }


            if (command == "Submit")
            {
                if (aAccountHeadModel.HEADNM != null && aAccountHeadModel.HEADTP != 0)
                {

                    //Get Ip ADDRESS,Time & user PC Name
                    string strHostName = System.Net.Dns.GetHostName();
                    IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                    IPAddress ipAddress = ipHostInfo.AddressList[0];


                    aAccountHeadModel.GLACCHARMSTModel.USERPC = strHostName;
                    aAccountHeadModel.GLACCHARMSTModel.INSIPNO = ipAddress.ToString();
                    aAccountHeadModel.GLACCHARMSTModel.INSTIME = Convert.ToDateTime(td);
                    //Insert User ID save POS_ITEMMST table attribute (INSUSERID) field
                    aAccountHeadModel.GLACCHARMSTModel.INSUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);

                    Int64 companyID = Convert.ToInt64(aAccountHeadModel.GLACCHARMSTModel.COMPID);


                    Int64 minCategoryId = Convert.ToInt64((from n in db.GlAccharmstDbSet where n.COMPID == companyID select n.HEADCD).Min());
                    //if (aAccountHeadModel.PosItemmstModel.CATID == null)
                    //{
                    //    aAccountHeadModel.PosItemmstModel.CATID = minCategoryId;
                    //}


                    var result = db.GlAccharmstDbSet.Count(d => d.HEADNM == aAccountHeadModel.HEADNM
                                                              && d.COMPID == companyID && d.HEADTP == aAccountHeadModel.HEADTP);
                    aAccountHeadModel.GLACCHARMSTModel.HEADNM = aAccountHeadModel.HEADNM;
                    aAccountHeadModel.GLACCHARMSTModel.HEADTP = aAccountHeadModel.HEADTP;
                    aAccountHeadModel.GLACCHARMSTModel.REMARKS = aAccountHeadModel.REMARKS;

                    if (result == 0)
                    {

                        //.........................................................Create Permission Check
                        var LoggedCompId = System.Web.HttpContext.Current.Session["loggedCompID"].ToString();
                        var loggedUserID = System.Web.HttpContext.Current.Session["loggedUserID"].ToString();

                        var createStatus = "";

                        System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GLDbContext"].ToString());
                        string query = string.Format("SELECT STATUS, INSERTR, UPDATER, DELETER FROM ASL_ROLE WHERE  CONTROLLERNAME='AccountHead' AND COMPID='{0}' AND USERID = '{1}'", LoggedCompId, loggedUserID);
                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable ds = new DataTable();
                        da.Fill(ds);

                        foreach (DataRow row in ds.Rows)
                        {
                            createStatus = row["INSERTR"].ToString();
                        }

                        conn.Close();

                        if (createStatus == 'I'.ToString())
                        {
                            TempData["AccountHead"] = aAccountHeadModel;
                            TempData["HeadCD"] = aAccountHeadModel.GLACCHARMSTModel.HEADCD;
                            TempData["HeadTP"] = aAccountHeadModel.GLACCHARMSTModel.HEADTP;
                            TempData["ShowAddButton"] = "Show Add Button";
                            TempData["message"] = "Permission not granted!";
                            return RedirectToAction("Index");
                        }
                        //...............................................................................................


                        AslUserco aslUserco = db.AslUsercoDbSet.FirstOrDefault(r => (r.COMPID == companyID));
                        if (aslUserco == null)
                        {
                            TempData["message"] = " User ID not found ";
                            TempData["ShowAddButton"] = "Show Add Button";
                        }
                        else
                        {
                            Int64 maxData = Convert.ToInt64((from n in db.GlAccharmstDbSet where n.COMPID == aAccountHeadModel.GLACCHARMSTModel.COMPID && n.HEADTP == aAccountHeadModel.GLACCHARMSTModel.HEADTP select n.HEADCD).Max());
                            string convertSubString = "";
                            string headerSubStringFind = "";
                            Int64 ConvertIntHeader = 0;
                            if (maxData != 0)
                            {
                                convertSubString = Convert.ToString(maxData);
                                headerSubStringFind = convertSubString.Substring(4, 2);
                                ConvertIntHeader = Convert.ToInt64(headerSubStringFind);
                                ConvertIntHeader++;
                            }


                            var HeadName = db.GlAccharmstDbSet.Count(d => d.HEADNM == aAccountHeadModel.GLACCHARMSTModel.HEADNM
                                                              && d.COMPID == companyID);
                            Int64 R = Convert.ToInt64(aAccountHeadModel.GLACCHARMSTModel.COMPID + "499");
                            //Int64 header = 0;
                            if (maxData == 0)
                            {
                                //header = 1;
                                string headtp = Convert.ToString(aAccountHeadModel.HEADTP);

                                aAccountHeadModel.GLACCHARMSTModel.HEADCD = Convert.ToInt64(aAccountHeadModel.GLACCHARMSTModel.COMPID + headtp + "01");


                                Insert_Headmst_LogData(aAccountHeadModel);

                                db.GlAccharmstDbSet.Add(aAccountHeadModel.GLACCHARMSTModel);
                                db.SaveChanges();

                                TempData["message"] = "Head Name: '" + aAccountHeadModel.GLACCHARMSTModel.HEADNM + "' successfully saved.\n Please Create the Account List.";
                                TempData["ShowAddButton"] = "Show Add Button";
                                TempData["AccountHead"] = aAccountHeadModel;
                                TempData["HeadCD"] = aAccountHeadModel.GLACCHARMSTModel.HEADCD;
                                TempData["HeadTP"] = aAccountHeadModel.GLACCHARMSTModel.HEADTP;

                                return RedirectToAction("Index");
                            }

                            else if (maxData <= R && ConvertIntHeader < 10 && HeadName != 0)
                            {

                                string headtp = Convert.ToString(aAccountHeadModel.HEADTP);
                                aAccountHeadModel.GLACCHARMSTModel.HEADCD = Convert.ToInt64(aAccountHeadModel.GLACCHARMSTModel.COMPID + headtp + "0" + ConvertIntHeader);


                                Insert_Headmst_LogData(aAccountHeadModel);

                                db.GlAccharmstDbSet.Add(aAccountHeadModel.GLACCHARMSTModel);
                                db.SaveChanges();

                                TempData["message"] = "Head Name: '" + aAccountHeadModel.GLACCHARMSTModel.HEADNM +
                                                      "' successfully saved.\n Please Create the Account List. ";
                                TempData["ShowAddButton"] = "Show Add Button";
                                TempData["AccountHead"] = aAccountHeadModel;
                                TempData["HeadCD"] = aAccountHeadModel.GLACCHARMSTModel.HEADCD;
                                TempData["HeadTP"] = aAccountHeadModel.GLACCHARMSTModel.HEADTP;
                                return RedirectToAction("Index");

                            }
                            else if (maxData <= R && ConvertIntHeader >= 10 && HeadName != 0)
                            {

                                string headtp = Convert.ToString(aAccountHeadModel.HEADTP);
                                aAccountHeadModel.GLACCHARMSTModel.HEADCD =
                                    Convert.ToInt64(aAccountHeadModel.GLACCHARMSTModel.COMPID + headtp + ConvertIntHeader);

                                //aAccountHeadModel.GLACCHARMSTModel.HEADCD = maxData + 1;


                                Insert_Headmst_LogData(aAccountHeadModel);

                                db.GlAccharmstDbSet.Add(aAccountHeadModel.GLACCHARMSTModel);
                                db.SaveChanges();

                                TempData["message"] = "Head Name: '" + aAccountHeadModel.GLACCHARMSTModel.HEADNM +
                                                      "' successfully saved.\n Please Create the Account List. ";
                                TempData["ShowAddButton"] = "Show Add Button";
                                TempData["AccountHead"] = aAccountHeadModel;
                                TempData["HeadCD"] = aAccountHeadModel.GLACCHARMSTModel.HEADCD;
                                TempData["HeadTP"] = aAccountHeadModel.GLACCHARMSTModel.HEADTP;
                                return RedirectToAction("Index");
                            }
                            else if (maxData <= R && ConvertIntHeader < 10 && HeadName == 0)
                            {

                                string headtp = Convert.ToString(aAccountHeadModel.HEADTP);
                                aAccountHeadModel.GLACCHARMSTModel.HEADCD =
                                    Convert.ToInt64(aAccountHeadModel.GLACCHARMSTModel.COMPID + headtp + "0" + ConvertIntHeader);

                                //aAccountHeadModel.GLACCHARMSTModel.HEADCD = maxData + 1;


                                Insert_Headmst_LogData(aAccountHeadModel);

                                db.GlAccharmstDbSet.Add(aAccountHeadModel.GLACCHARMSTModel);
                                db.SaveChanges();

                                TempData["message"] = "Head Name: '" + aAccountHeadModel.GLACCHARMSTModel.HEADNM +
                                                      "' successfully saved.\n Please Create the Account List. ";
                                TempData["ShowAddButton"] = "Show Add Button";
                                TempData["AccountHead"] = aAccountHeadModel;
                                TempData["HeadCD"] = aAccountHeadModel.GLACCHARMSTModel.HEADCD;
                                TempData["HeadTP"] = aAccountHeadModel.GLACCHARMSTModel.HEADTP;
                                return RedirectToAction("Index");
                            }
                            else if (maxData <= R && ConvertIntHeader >= 10 && HeadName == 0)
                            {

                                string headtp = Convert.ToString(aAccountHeadModel.HEADTP);
                                aAccountHeadModel.GLACCHARMSTModel.HEADCD =
                                    Convert.ToInt64(aAccountHeadModel.GLACCHARMSTModel.COMPID + headtp + ConvertIntHeader);

                                //aAccountHeadModel.GLACCHARMSTModel.HEADCD = maxData + 1;

                                Insert_Headmst_LogData(aAccountHeadModel);

                                db.GlAccharmstDbSet.Add(aAccountHeadModel.GLACCHARMSTModel);
                                db.SaveChanges();

                                TempData["message"] = "Head Name: '" + aAccountHeadModel.GLACCHARMSTModel.HEADNM +
                                                      "' successfully saved.\n Please Create the Account List. ";
                                TempData["ShowAddButton"] = "Show Add Button";
                                TempData["AccountHead"] = aAccountHeadModel;
                                TempData["HeadCD"] = aAccountHeadModel.GLACCHARMSTModel.HEADCD;
                                TempData["HeadTP"] = aAccountHeadModel.GLACCHARMSTModel.HEADTP;
                                return RedirectToAction("Index");
                            }

                            else
                            {
                                TempData["ShowAddButton"] = "Show Add Button";
                                TempData["message"] = "Not possible entry ";
                                return RedirectToAction("Index");
                            }
                        }
                    }
                    else if (result > 0)
                    {
                        var ans = from n in db.GlAccharmstDbSet
                                  where n.COMPID == companyID && n.HEADNM == aAccountHeadModel.GLACCHARMSTModel.HEADNM
                                      && n.HEADTP == aAccountHeadModel.GLACCHARMSTModel.HEADTP
                                  select new { n.HEADCD };
                        foreach (var a in ans)
                        {
                            aAccountHeadModel.GLACCHARMSTModel.HEADCD = a.HEADCD;
                        }

                        //TempData["message"] = "Get the Item List";
                        TempData["ShowAddButton"] = "Show Add Button";
                        TempData["AccountHead"] = aAccountHeadModel;
                        TempData["HeadCD"] = aAccountHeadModel.GLACCHARMSTModel.HEADCD;
                        TempData["HeadTP"] = aAccountHeadModel.GLACCHARMSTModel.HEADTP;
                        TempData["latitute_deleteAccount"] = aAccountHeadModel.GLACCHARMSTModel.INSLTUDE;
                        return RedirectToAction("Index");
                    }
                }

                else if (aAccountHeadModel.HEADNM == null && aAccountHeadModel.HEADTP == 0)
                {
                    ViewBag.CategoryMsg = "Please Select Head Type and Enter Head Name.";
                    return View("Index");
                }



            }

            if (command == "Update")
            {
                var query =
                    from a in db.GlAcchartDbSet
                    where (a.ACCOUNTCD == aAccountHeadModel.AcchartModel.ACCOUNTCD && a.COMPID == aAccountHeadModel.GLACCHARMSTModel.COMPID && a.HEADCD == aAccountHeadModel.GLACCHARMSTModel.HEADCD)
                    select a;
                aAccountHeadModel.AcchartModel.COMPID = aAccountHeadModel.GLACCHARMSTModel.COMPID;
                aAccountHeadModel.AcchartModel.HEADCD = aAccountHeadModel.GLACCHARMSTModel.HEADCD;
                aAccountHeadModel.GLACCHARMSTModel.HEADTP = aAccountHeadModel.HEADTP;

                foreach (GL_ACCHART a in query)
                {
                    // Insert any additional changes to column values.
                    a.ACCOUNTNM = aAccountHeadModel.AcchartModel.ACCOUNTNM;


                    a.REMARKS = aAccountHeadModel.AcchartModel.REMARKS;
                    a.UPDIPNO = ipAddress.ToString();
                    a.UPDTIME = td;
                    a.UPDUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                    a.UPDLTUDE = aAccountHeadModel.GLACCHARMSTModel.INSLTUDE;
                    TempData["AccountLogData"] = Convert.ToString("Head ID: " + a.HEADCD + ",\nAccount ID: " + a.ACCOUNTCD + ",\nAccount Name: " + a.ACCOUNTNM + ",\nAccount type: " + a.HEADTP + ",\nRemarks: " + a.REMARKS + ".");

                }

                ASL_LOG aslLogref = new ASL_LOG();

                aslLogref.LOGIPNO = ipAddress.ToString();
                aslLogref.COMPID = aAccountHeadModel.AcchartModel.COMPID;
                aAccountHeadModel.AcchartModel.INSLTUDE = aAccountHeadModel.GLACCHARMSTModel.INSLTUDE;
                aslLogref.LOGLTUDE = aAccountHeadModel.AcchartModel.INSLTUDE;

                //Update User ID save ASL_ROLE table attribute UPDUSERID
                aslLogref.USERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                aslLogref.LOGDATA = TempData["AccountLogData"].ToString();
                Update_GL_ACCHART_LogData(aslLogref);

                db.SaveChanges();

                TempData["AccountHead"] = aAccountHeadModel;
                TempData["HeadCD"] = aAccountHeadModel.AcchartModel.HEADCD;
                TempData["HeadTP"] = aAccountHeadModel.GLACCHARMSTModel.HEADTP;
                TempData["ShowAddButton"] = "Show Add Button";
                aAccountHeadModel.AcchartModel.ACCOUNTNM = "";

                aAccountHeadModel.AcchartModel.REMARKS = "";
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }


        public ActionResult EditAccountUpdate(Int64 id, Int64 cid, int headtype, Int64 Headid, Int64 itemId, string itemname, AccountHeadModel model)
        {
            //.........................................................Create Permission Check
            var LoggedCompId = System.Web.HttpContext.Current.Session["loggedCompID"].ToString();
            var loggedUserID = System.Web.HttpContext.Current.Session["loggedUserID"].ToString();

            var updateStatus = "";

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GLDbContext"].ToString());
            string query1 = string.Format("SELECT STATUS, INSERTR, UPDATER, DELETER FROM ASL_ROLE WHERE  CONTROLLERNAME='AccountHead' AND COMPID='{0}' AND USERID = '{1}'", LoggedCompId, loggedUserID);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query1, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            foreach (DataRow row in ds.Rows)
            {
                updateStatus = row["UPDATER"].ToString();
            }
            conn.Close();

            //add the data from database to model
            var HeadName_Remarks = from m in db.GlAccharmstDbSet where m.HEADCD == Headid && m.COMPID == cid select m;
            foreach (var categoryResult in HeadName_Remarks)
            {
                model.GLACCHARMSTModel.COMPID = cid;
                model.GLACCHARMSTModel.HEADCD = Headid;
                model.GLACCHARMSTModel.HEADNM = categoryResult.HEADNM;
                model.GLACCHARMSTModel.HEADTP = categoryResult.HEADTP;
                model.GLACCHARMSTModel.REMARKS = categoryResult.REMARKS;
            }
            model.HEADTP = model.GLACCHARMSTModel.HEADTP;
            model.HEADNM = model.GLACCHARMSTModel.HEADNM;
            TempData["AccountHead"] = model;
            TempData["HeadCD"] = Headid;
            TempData["HeadTP"] = model.GLACCHARMSTModel.HEADTP;
            TempData["ShowAddButton"] = null;
            if (updateStatus == 'I'.ToString())
            {
                TempData["message"] = "Permission not granted!";
                return RedirectToAction("Index");
            }
            //...............................................................................................

            model.AcchartModel = db.GlAcchartDbSet.Find(id);

            var item = from r in db.GlAcchartDbSet where r.ACCHARTId == id select r.ACCOUNTNM;
            foreach (var it in item)
            {
                model.AcchartModel.ACCOUNTNM = it.ToString();
            }

            return RedirectToAction("Index");

        }


        public ActionResult AccountDelete(Int64 id, Int64 cid, int headtype, Int64 Headid, Int64 itemId, string itemname, AccountHeadModel model)
        {
            //.........................................................Create Permission Check
            var LoggedCompId = System.Web.HttpContext.Current.Session["loggedCompID"].ToString();
            var loggedUserID = System.Web.HttpContext.Current.Session["loggedUserID"].ToString();

            var deleteStatus = "";

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GLDbContext"].ToString());
            string query = string.Format("SELECT STATUS, INSERTR, UPDATER, DELETER FROM ASL_ROLE WHERE  CONTROLLERNAME='AccountHead' AND COMPID='{0}' AND USERID = '{1}'", LoggedCompId, loggedUserID);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            foreach (DataRow row in ds.Rows)
            {
                deleteStatus = row["DELETER"].ToString();
            }
            conn.Close();
            //add the data from database to model
            var HeadName_Remarks = from m in db.GlAccharmstDbSet where m.HEADCD == Headid && m.COMPID == cid select m;
            foreach (var categoryResult in HeadName_Remarks)
            {
                model.GLACCHARMSTModel.COMPID = cid;
                model.GLACCHARMSTModel.HEADCD = Headid;
                model.GLACCHARMSTModel.HEADNM = categoryResult.HEADNM;
                model.GLACCHARMSTModel.HEADTP = categoryResult.HEADTP;
                model.GLACCHARMSTModel.REMARKS = categoryResult.REMARKS;
            }
            model.HEADTP = model.GLACCHARMSTModel.HEADTP;
            model.HEADNM = model.GLACCHARMSTModel.HEADNM;
            TempData["AccountHead"] = model;
            TempData["HeadCD"] = Headid;
            TempData["HeadTP"] = model.GLACCHARMSTModel.HEADTP;
            TempData["ShowAddButton"] = "Show Add Button";
            if (deleteStatus == 'I'.ToString())
            {
                TempData["message"] = "Permission not granted!";
                return RedirectToAction("Index");

            }
            //...............................................................................................

            GL_ACCHART Accountitem = db.GlAcchartDbSet.Find(id);
            //Get Ip ADDRESS,Time & user PC Name
            string strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];

            Accountitem.USERPC = strHostName;
            Accountitem.UPDIPNO = ipAddress.ToString();
            Accountitem.UPDTIME = Convert.ToDateTime(td);
            //Delete User ID save POS_ITEMMST table attribute (UPDUSERID) field
            Accountitem.UPDUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);

            if (TempData["latitute_deleteAccount"] != null)
            {
                //Get current LOGLTUDE data 
                Accountitem.UPDLTUDE = TempData["latitute_deleteAccount"].ToString();
            }

            //Check CNF_JOBRCV attribute PartyID 
            //var result =
            //    (from m in db.CnfJobrcvs where m.COMPID == cid && (m.PARTYID == itemId || m.DEBITCD == itemId) select m)
            //        .Count();

            //if (result != 0)
            //{
            //    TempData["message"] = "Your Account name already connected with job receive information!";
            //}
            //else
            //{
            //    Delete_GL_ACCHART_LogData(Accountitem);
            //    Delete_ASL_DELETE_ACCHART(Accountitem);
            //    db.GlAcchartDbSet.Remove(Accountitem);
            //    db.SaveChanges();
            //}

            Delete_GL_ACCHART_LogData(Accountitem);
            Delete_ASL_DELETE_ACCHART(Accountitem);
            db.GlAcchartDbSet.Remove(Accountitem);
            db.SaveChanges();

            return RedirectToAction("Index");
        }








        //AutoComplete 
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ItemNameChanged(string changedText, int headTypeText)
        {
            var compid = Convert.ToInt16(System.Web.HttpContext.Current.Session["loggedCompID"].ToString());


            String name = "";

            var rt = db.GlAccharmstDbSet.Where(n => n.HEADNM.StartsWith(changedText) && n.HEADTP == headTypeText &&
                                                         n.COMPID == compid).Select(n => new
                                                         {
                                                             headname = n.HEADNM

                                                         }).ToList();
            int lenChangedtxt = changedText.Length;

            Int64 cont = rt.Count();
            Int64 k = 0;
            string status = "";
            if (changedText != "" && cont != 0)
            {
                while (status != "no")
                {
                    k = 0;
                    foreach (var n in rt)
                    {
                        string ss = Convert.ToString(n.headname);
                        string subss = "";
                        if (ss.Length >= lenChangedtxt)
                        {
                            subss = ss.Substring(0, lenChangedtxt);
                            subss = subss.ToUpper();
                        }
                        else
                        {
                            subss = "";
                        }


                        if (subss == changedText.ToUpper())
                        {
                            k++;
                        }
                        if (k == cont)
                        {
                            status = "yes";
                            lenChangedtxt++;
                            if (ss.Length > lenChangedtxt - 1)
                            {
                                changedText = changedText + ss[lenChangedtxt - 1];
                            }

                        }
                        else
                        {
                            status = "no";
                            //lenChangedtxt--;
                        }

                    }

                }
                if (lenChangedtxt == 1)
                {
                    name = changedText.Substring(0, lenChangedtxt);
                }

                else
                {
                    name = changedText.Substring(0, lenChangedtxt - 1);
                }



            }
            else
            {
                name = changedText;
            }







            String itemId2 = "";
            string remarks = "";
            var rt2 = db.GlAccharmstDbSet.Where(n => n.HEADNM == name && n.HEADTP == headTypeText &&
                                                         n.COMPID == compid).Select(n => new
                                                         {
                                                             Headid = n.HEADCD,
                                                             rmks = n.REMARKS
                                                         });
            foreach (var n in rt2)
            {
                itemId2 = Convert.ToString(n.Headid);
                remarks = Convert.ToString(n.rmks);
            }

            var result = new { HeadName = name, headid = itemId2, rmrks = remarks };
            return Json(result, JsonRequestBehavior.AllowGet);

        }



        //AutoComplete
        public JsonResult TagSearch(string term, int changedDropDown)
        {
            var compid = Convert.ToInt16(System.Web.HttpContext.Current.Session["loggedCompID"].ToString());

            //Int64 categoryID = Convert.ToInt64(changedDropDown);
            if (changedDropDown == 0)
            {

                return this.Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var typeId = Convert.ToInt64(changedDropDown);

                var tags = from p in db.GlAccharmstDbSet
                           where p.COMPID == compid && p.HEADTP == typeId
                           select p.HEADNM;

                return this.Json(tags.Where(t => t.StartsWith(term)),
                           JsonRequestBehavior.AllowGet);
            }



        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
