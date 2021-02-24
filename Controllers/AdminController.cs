using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web.Mvc;
using Longhaul_BO;
using LonghaulWhatsApp.DA;

namespace LonghaulWhatsApp.Controllers
{


    public class AdminController : Controller
    {
        DA.UserDA DB = new DA.UserDA();

        public ActionResult Not_Authorize()
        {
            return View("Not_Authorize");
        }



        public ActionResult Pending_Approvals()
        {

            try
            {
                if (Session["username"].ToString() == null)
                {
                    return RedirectToAction("Index", "Home");
                }
               

                DataSet ds = DB.Pending_Approval_Users();
                ViewBag.Pending_Users = ds.Tables[0];


                ds = DB.Approved_Users();
                ViewBag.Approved_Users = ds.Tables[0];

                ViewBag.msg = "success1...!!";
                return View("Pending_Approvals", "_Layout");

            }
            catch (Exception e)
            {

                ViewBag.Exception = e;
            }

            return View("Pending_Approvals", "_Layout");

        }


        [HttpPost]
        public ActionResult Approval_UsersData(int id, string PaymentRefNo, string basepath, string InstanceId, string Token, string Remarks, string approval, string approvaldate, string channleid)
        {
            try
            {
                if (Session["username"].ToString() == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                DataSet ds = new DataSet();
                DB.admin_userapproval(PaymentRefNo, basepath, InstanceId, Token, Remarks, approval, approvaldate, channleid);
                ds = DB.User_Approvaldata(id);

                //ViewBag.flag = 1;
                //ViewBag.msg = "success...!!";



            }
            catch (Exception e)
            {

                ViewBag.Exception = e;

            }


            return RedirectToAction("Pending_Approvals");
        }

        public ActionResult All_ApprovalUserdata()
        {
            try
            {
                if (Session["username"].ToString() == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                DataSet ds = new DataSet();
                ds = DB.All_Approved_Users();
                ViewBag.All_Approavl_Users = ds.Tables[0];
            }
            catch (Exception e)
            {
                ViewBag.Exception = e;

            }
            return View("All_ApprovalUserdata", "_Layout");
        }



    }
}