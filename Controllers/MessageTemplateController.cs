using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LonghaulWhatsApp.DA;

namespace login_and_menu.Controllers
{
    public class MessageTemplateController : Controller
    {
        UserDA DA = new UserDA();
        // GET: MessageTemplate
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            ViewBag.Date = DateTime.Today.ToString(); 
            ViewBag.username = Session["username"];
            return View("List", "_Layout");
        }

        [HttpPost]
        public ActionResult List(string templatetitle, string Description)
        {
            try
            {
                ViewBag.Date = DateTime.Today.ToString();
                ViewBag.username = Session["username"];
                DA.msg_Template_header(templatetitle, Description, ViewBag.username);
            }
            catch (Exception e)
            {
                ViewBag.Exception = e;
            }
            return View("List", "_Layout");
        }

        public ActionResult Create()
        {
            return View("Create", "_Layout");
        }
    }
}