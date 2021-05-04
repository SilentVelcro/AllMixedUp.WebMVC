using AllMixedUp.Services;
using AllMixedUp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllMixedUp.Data;
using AllMixedUp.Models.Ingredient;

namespace AllMixedUp.WebMVC.Controllers
{
    [Authorize]
    public class IngredientController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

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
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateIngredientService();

            if (service.CreateIngredient(model))
            {
                TempData["SaveResult"] = "Your Ingredient was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Ingredient could not be created.");

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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = CreateIngredientService();
            var detail = service.GetIngredientById(id);
            var serviceTwo = new MaterialService(userId);




            var model = new IngredientEdit
            {
                CreatedDate = detail.CreatedDate,
                GlazeID = detail.GlazeID,
                IngredientID = detail.IngredientID,
                MaterialID = detail.MaterialID,
                MaterialName = detail.MaterialName,
                ModifiedDate = detail.ModifiedDate,
                OwnerId = userId,
                Quantity = detail.Quantity
            };
            //model.GlazeID = id;
            //model.OwnerId = userId;
            //model.MaterialID = 1;
            //ViewBag.Materials = new SelectList(serviceTwo.GetMaterial().ToList(), "MaterialID", "MaterialName");
            ViewData["Materials"] = _db.Material.Select(p => new SelectListItem { Text = p.MaterialName, Value = p.MaterialID.ToString() });
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IngredientEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateIngredientService();
            ViewData["Materials"] = _db.Material.Select(p => new SelectListItem { Text = p.MaterialName, Value = p.MaterialID.ToString() });

            if (model.IngredientID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

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

        //ADD INGREDIENT TO GLAZE--------------------------------------------------------------------------------------

        public ActionResult AddIngredientToList(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaterialService(userId);
            var model = new IngredientCreate();
            model.GlazeID = id;
            model.OwnerId = userId;
            model.MaterialID = 1;
            ViewBag.Materials = new SelectList(service.GetMaterial().ToList(), "MaterialID", "MaterialName");
            return View(model);
        }

        [HttpPost]

        public ActionResult AddIngredientToList(int id, IngredientCreate model)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            var service = CreateIngredientService();

            if (service.CreateIngredient(model))
            {
                TempData["SaveResult"] = "Your Ingredient was created.";
                return RedirectToAction("Index");
            };

            //RUN SERVICE----------------------------------
            //service.CreateGlazeIngredientList(id, model);

            ////SUBMIT-----------------------------------------
            //if (Request.Form["Add aother ingredient"] != null)
            //{
            //    _db.SaveChanges();

            //    TempData["SaveResult"] = "Your ingredient(s) have been created.";
            //    return RedirectToAction("AddIngredientToList", new { glazeID = model.GlazeIngredientList });

            //}
            ////ADD ANOTHER INGREDIENT----------------------------------
            //if (Request.Form["AddIngredientToList"] != null)
            //{
            //    _db.SaveChanges();

            //    TempData["SaveResult"] = "Your ingredient list has been created.";
            //    return RedirectToAction("Index", new { glazeID = model.GlazeIngredientList });
            //}

            ModelState.AddModelError("", "Ingredients could not be created.");

            return View(model);
        }

    }
}