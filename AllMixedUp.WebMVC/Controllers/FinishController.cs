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
    public class FinishController : Controller
    {
        // GET: Finish
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FinishService(userId);
            var model = service.GetFinish();
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
        public ActionResult Create(FinishCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFinishService();

            if (service.CreateFinish(model))
            {
                TempData["SaveResult"] = "Your finish was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Finish could not be created.");

            return View(model);
        }

        //DETAIL
        public ActionResult Details(int id)
        {
            var svc = CreateFinishService();
            var model = svc.GetFinishById(id);

            return View(model);
        }

        //EDIT
        public ActionResult Edit(int id)
        {
            var service = CreateFinishService();
            var detail = service.GetFinishById(id);
            var model =
                new FinishEdit
                {
                    FinishID = detail.FinishID,
                    Opacity = detail.Opacity,
                    Surface = detail.Surface,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FinishEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FinishID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFinishService();

            if (service.UpdateFinish(model))
            {
                TempData["SaveResult"] = "Your finish was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your finish could not be updated.");
            return View(model);
        }

        //DELETE
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFinishService();
            var model = svc.GetFinishById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFinish(int id)
        {
            var service = CreateFinishService();

            service.DeleteFinish(id);

            TempData["SaveResult"] = "Finish was deleted";

            return RedirectToAction("Index");
        }

        //HELPER METHOD
        private FinishService CreateFinishService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FinishService(userId);
            return service;
        }
    }
}