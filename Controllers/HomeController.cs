using System.Collections.Generic;
using System.Web.Mvc;
using LonghaulWhatsApp.DA;
using Longhaul_BO;
using System.Data;
using Longhaul_DA;
using System;
using System.Web.Security;

namespace LonghaulWhatsApp.Controllers
{
    public class HomeController : Controller
    {
        UserDA DB = new UserDA();
        //GET: Home

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
      
        public ActionResult login(string empcd, string password)
        {

            BO_Employee objResult = new BO_Employee();
            
            try
            {
                objResult = DA_Login.DA_LoginEmployee(empcd, password);

                if (objResult.Empcd != null && objResult.Password != null)
                {
                    // if (obj.Empcd.Trim() == objResult.Empcd.Trim() && obj.Password.Trim() == objResult.Password.Trim())
                    if (empcd.Trim() == objResult.Empcd.Trim() && password.Trim() == objResult.Password.Trim())
                    {
                        // Session["EntryBy"] = obj.Empcd;
                        Session["EntryBy"] = objResult.Empcd;
                        Session["Password"] = objResult.Password;
                        Session["username"] = objResult.Empnm;

                        TempData["success"] = 1;

                        return RedirectToAction("Home");

                        //if (objResult.Empcd.Trim() == "A786KEY")
                        //{
                        //    ViewBag.flag = 1;
                        //}
                       // return View("main", "_Layout");


                    }
                }



                ViewBag.fail = 0;
            }
            catch (Exception e)
            {
                ViewBag.Exception = e;
                // throw;
            }
            return View("Index");
        }

        public ActionResult Home()
        {

            try
            {
                DataSet ds = new DataSet();
                ds = DB.Count_msgs();
                //ViewBag.Totalmsgs = ds.Tables[0];

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ViewBag.Totalmsgs = dr["Total_msgs"].ToString();
                }

                // ViewBag.Todaymsgs = ds.Tables[1];

                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    ViewBag.Todaymsgs = dr["Today_msgs"].ToString();
                }


                if (Session["username"].ToString() == null)
                {
                    return View("Home", "Index");
                }
                ViewBag.Home = true;
               
            }
            catch (Exception e)
            {
                ViewBag.Exception = e;

            }
            return View("Home", "_Layout");
        }


        public ActionResult admin()
        {
            try
            {
                if (Session["username"] == null)
                {
                    BO_Employee obj = new BO_Employee();

                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {

                
            }


            return View("admin", "_Layout");
        }


        public ActionResult register()
        {
              return View();
        }


        [HttpPost]
        //public ActionResult register(FormCollection FC)
        public ActionResult register(string username, string email, string mbl_no, string password, string cnfrm_password, string ref_code)
        {
            try
            {
                DB.register(username, email, mbl_no, password, cnfrm_password, ref_code);
                ViewBag.success = 0;
            }
            catch (Exception e)
            {
                ViewBag.Exception = e;

            }
            return View("register");
        }


        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", null);
        }



        [HttpGet]
        public ActionResult employee1()
        {

            try
            {
                if (Session["username"] == null)
                {
                    BO_Employee obj = new BO_Employee();

                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception )
            {

               
            }

            return View("employee1", "_Layout");
        }



        public JsonResult Get_employee(int pageindex, int pagesize)
        {
            All_user_RegisterList rslist = new All_user_RegisterList();
            try
            {
               

                rslist = DB.Get_Paging_data(pagesize, pageindex);
            }
            catch (Exception )
            {

               
            }

            return Json(rslist, JsonRequestBehavior.AllowGet);

        }




        [HttpPost]
        public ActionResult selectddata(List<Report_users> values)
        {

            try
            {

                DataTable dt = new DataTable();
                DB.selected_employees(values);
                ViewBag.inertmsg = "Selected data inserted";
                ViewBag.success = 1;
            }
            catch (Exception e)
            {
                ViewBag.Exception = e;

            }
            return View("employee1", "_Layout");
        }


        public ActionResult Report()
        {

            DataSet ds = new DataSet();
            try
            {

                ds = DB.get_UserReport();
            }
            catch (Exception e)
            {
                ViewBag.Exception = e;
                //throw;
            }
            return View("Report", "_Layout", ds);
        }



    }
}