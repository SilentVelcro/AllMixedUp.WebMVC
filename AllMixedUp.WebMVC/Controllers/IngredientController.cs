using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllMixedUp.WebMVC.Controllers
{
    [Authorize]
    public class IngredientController : Controller
    {
        // GET: Ingredient
        public ActionResult Index()
        {
            return View();
        }
    }
}