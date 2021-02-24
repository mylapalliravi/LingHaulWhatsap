using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace login_and_menu.Controllers
{
    public class MissedCallController : Controller
    {
        // GET: MissedCall
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult linked()
        {
            return View("linked","_Layout");
        }
    }
}