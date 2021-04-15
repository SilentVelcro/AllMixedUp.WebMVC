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
    public class MaterialController : Controller
    {
        // GET: Material
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaterialService(userId);
            var model = service.GetMaterial();
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
        public ActionResult Create(MaterialCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMaterialService();

            if (service.CreateMaterial(model))
            {
                TempData["SaveResult"] = "Your material was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Material could not be created.");

            return View(model);
        }

        //DETAIL
        public ActionResult Details(int id)
        {
            var svc = CreateMaterialService();
            var model = svc.GetMaterialById(id);

            return View(model);
        }

        //EDIT
        public ActionResult Edit(int id)
        {
            var service = CreateMaterialService();
            var detail = service.GetMaterialById(id);
            var model =
                new MaterialEdit
                {
                    //UserID = detail.UserID,
                    //FirstName = detail.FirstName,
                    //LastName = detail.LastName,
                    //Email = detail.Email,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MaterialEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MaterialID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMaterialService();

            if (service.UpdateMaterial(model))
            {
                TempData["SaveResult"] = "Your material was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your material could not be updated.");
            return View(model);
        }

        //DELETE
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMaterialService();
            var model = svc.GetMaterialById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMaterial(int id)
        {
            var service = CreateMaterialService();

            service.DeleteMaterial(id);

            TempData["SaveResult"] = "Material was deleted";

            return RedirectToAction("Index");
        }

        //HELPER METHOD
        private MaterialService CreateMaterialService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaterialService(userId);
            return service;
        }
    }
}