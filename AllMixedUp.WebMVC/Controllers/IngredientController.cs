using AllMixedUp.Services;
using AllMixedUp.Models;
using Microsoft.AspNet.Identity;
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IngredientService(userId);
            var model = service.GetIngredient();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateIngredientService();

            if (service.CreateIngredient(model))
            {
                TempData["SaveResult"] = "Your glaze was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Glaze could not be created.");

            return View(model);
        }

        //DETAIL
        public ActionResult Details(int id)
        {
            var svc = CreateIngredientService();
            var model = svc.GetIngredientById(id);

            return View(model);
        }

        //EDIT
        public ActionResult Edit(int id)
        {
            var service = CreateIngredientService();
            var detail = service.GetIngredientById(id);
            var model =
                new IngredientEdit
                {
                    MaterialID = detail.MaterialID,
                    Quantity = detail.Quantity,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IngredientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.IngredientID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateIngredientService();

            if (service.UpdateIngredient(model))
            {
                TempData["SaveResult"] = "Your ingredient was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your ingredient could not be updated.");
            return View(model);
        }

        //DELETE
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateIngredientService();
            var model = svc.GetIngredientById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteIngredient(int id)
        {
            var service = CreateIngredientService();

            service.DeleteIngredient(id);

            TempData["SaveResult"] = "Ingredient was deleted";

            return RedirectToAction("Index");
        }

        //HELPER METHOD
        private IngredientService CreateIngredientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IngredientService(userId);
            return service;
        }
    }
}