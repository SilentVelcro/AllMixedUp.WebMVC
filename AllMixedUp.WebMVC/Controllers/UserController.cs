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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserService(userId);
            var model = service.GetUser();
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
        public ActionResult Create(UserCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateUserService();

            if (service.CreateUser(model))
            {
                TempData["SaveResult"] = "Your User was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "User could not be created.");

            return View(model);
        }

        //Detail
        public ActionResult Details(int id)
        {
            var svc = CreateUserService();
            var model = svc.GetUserById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateUserService();
            var detail = service.GetUserById(id);
            var model =
                new UserEdit
                {
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Email = detail.Email,
                };
            return View(model);
        }

        //HELPER METHOD
        private UserService CreateUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserService(userId);
            return service;
        }
    }
}