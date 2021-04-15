using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllMixedUp.WebMVC.Controllers
{
    [Authorize]
    public class FinishController : Controller
    {
        // GET: Finish
        public ActionResult Index()
        {
            return View();
        }
    }
}