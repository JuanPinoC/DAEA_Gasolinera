using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebInterface.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ErrorAuth()
        {
            return View();
        }
        public ActionResult ErrorPerm()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }
    }
}