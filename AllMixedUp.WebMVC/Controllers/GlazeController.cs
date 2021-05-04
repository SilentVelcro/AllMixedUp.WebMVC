using AllMixedUp.Models;
using AllMixedUp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllMixedUp.WebMVC.Controllers
{
        [Authorize]

    public class GlazeController : Controller
    {
        //GET / GLAZE / INDEX
        public ActionResult Index()
        {
            var service = CreateGlazeService();
            var model = service.GetAllGlazes();
            return View(model);
        }

        //CREATE ---------------------------------------------------------------------------
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GlazeCreate model)
        {
            if (!ModelState.IsValid) 
                return View(model);

            var service = CreateGlazeService();
            //int createdGlaze = service.CreateGlaze(model);

            if (service.CreateGlaze(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        //DETAIL -----------------------------------------------------------------------
        public ActionResult Details(int id)
        {
            var svc = CreateGlazeService();
            var model = svc.GetGlazeById(id);

            return View(model);
        }

        //EDIT --------------------------------------------------------------------------
        public ActionResult Edit(int id)
        {
            var service = CreateGlazeService();
            var detail = service.GetGlazeById(id);
            var model =
                new GlazeEdit
                {
                    GlazeID = detail.GlazeID,
                    GlazeName = detail.GlazeName,
                    IngredientList = detail.IngredientList,
                    Description = detail.Description,
                    Atmosphere = detail.Atmosphere,
                    MinCone = detail.MinCone,
                    MainColor = detail.MainColor,
                    FoodSafe = detail.FoodSafe,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GlazeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GlazeID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGlazeService();

            if (service.UpdateGlaze(model))
            {
                TempData["SaveResult"] = "Your glaze was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your glaze could not be updated.");
            return View(model);
        }

        //DELETE ------------------------------------------------------------------
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGlazeService();
            var model = svc.GetGlazeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGlaze(int id)
        {
            var service = CreateGlazeService();

            service.DeleteGlaze(id);

            TempData["SaveResult"] = "Glaze was deleted";

            return RedirectToAction("Index");
        }

        //HELPER METHOD
        private GlazeService CreateGlazeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GlazeService(userId);
            return service;
        }
    }
}