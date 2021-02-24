using System;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using LonghaulWhatsApp.DA;
using System.Configuration;
using System.IO;
using Longhaul_BO;
using System.Data;

namespace login_and_menu.Controllers
{
    public class MessageController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnectionstring"].ConnectionString);
        UserDA DB = new UserDA();
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public ActionResult CreateMessage()
        {
            if (Session["username"].ToString() == null)
            {
                return RedirectToAction("Index", "Home");
            }



            //image display code from database in byte format to image

            //DataTable ds1 = DB.Pending_pics();
            //if (ds1 != null)
            //{
            //    // byte[] ImagemByte = (byte[])ds1.Rows[0][8];
            //    // MemoryStream ms = new MemoryStream(ImagemByte);
            //    // String base64 = Convert.ToBase64String(ImagemByte);
            //    // var imgSrc = String.Format("data:image/jpg;base64,{0}", base64);
            //    var imgSrc = ds1.Rows[0][3];
            //    VigewBag.image = imgSrc;

            //    //var pdf = ds1.Rows[0][8].ToString();
            //    //ViewBag.pdf = pdf;

            //}




            if (Session["username"] == null)
            {
                BO_Employee obj = new BO_Employee();

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateMessage(string ph_textarea, string msg_textarea, HttpPostedFileBase files)
        {
            var fname = "";
            var Extention = "";
            int filesize = 0;
            var ContentType = "";
            var filepath = "";

            string entryby = "";
            entryby = Session["EntryBy"].ToString();

            if (files == null)
            {
                //  ViewBag.file = 2;
                DB.validate_mbleno(ph_textarea, msg_textarea, entryby, fname, filepath, ContentType, filesize, Extention, false);
            }
            else
            {
                try
                {

                    if (files.ContentLength > 0)
                    {
                        HttpPostedFileBase hfb = files;
                        fname = Path.GetFileName(hfb.FileName);
                        Extention = Path.GetExtension(hfb.FileName);
                        filesize = hfb.ContentLength;
                        ContentType = hfb.ContentType;
                        filepath = "";

                        fname = Guid.NewGuid().ToString() + Extention;

                        if (Extention == ".jpg" || Extention == ".png" || Extention == ".gif" || Extention == ".bmp" || Extention == ".pdf" || Extention == ".txt")
                        {
                            // filepath = Path.Combine(Server.MapPath("~/files/") + fname);
                            filepath = Path.Combine(ConfigurationManager.AppSettings["WhatsAppAttachment"].ToString() + fname);

                            files.SaveAs(filepath);
                            filepath = Path.Combine(ConfigurationManager.AppSettings["WhatsAppAttachment"].ToString());
                        }

                        entryby = Session["EntryBy"].ToString();
                        DB.validate_mbleno(ph_textarea, msg_textarea, entryby, fname, filepath, ContentType, filesize, Extention, true);

                        ViewBag.Success = 1;

                    }

                }
                catch (Exception e)
                {

                    ViewBag.Exception = e;
                }


                entryby = Session["EntryBy"].ToString();
            }

            return View("CreateMessage", "_Layout");
        }

        public ActionResult CreateMessage_Extractor()
        {
            return View("CreateMessage_Extractor", "_Layout");
        }

        [HttpPost]
        public ActionResult insert_CreateMessage_Extractor(string ph_textarea, string msg_textarea, string entryby)
        {


            try
            {
                //  DB.insert(ph_textarea, msg_textarea, entryby);
                ViewBag.success = 1;
            }
            catch (Exception e)
            {
                ViewBag.Exception = e;

            }
            return View("CreateMessage_Extractor", "_Layout");
        }
        public ActionResult CreateCsv()
        {
            return View("CreateCsv", "_Layout");
        }

        [HttpPost]
        public ActionResult imagedisplay()
        {
            return View("CreateCsv", "_Layout");
        }
    }
}