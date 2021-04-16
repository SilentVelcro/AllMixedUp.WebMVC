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
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MessageService(userId);
            var model = service.GetMessage();
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
        public ActionResult Create(MessageCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMessageService();

            if (service.CreateMessage(model))
            {
                TempData["SaveResult"] = "Your message was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Message could not be created.");

            return View(model);
        }

        //DETAIL
        public ActionResult Details(int id)
        {
            var svc = CreateMessageService();
            var model = svc.GetMessageById(id);

            return View(model);
        }

        //EDIT
        public ActionResult Edit(int id)
        {
            var service = CreateMessageService();
            var detail = service.GetMessageById(id);
            var model =
                new MessageEdit
                {
                    MessageID = detail.MessageID,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MessageEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MessageID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMessageService();

            if (service.UpdateMessage(model))
            {
                TempData["SaveResult"] = "Your message was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your message could not be updated.");
            return View(model);
        }

        //DELETE
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMessageService();
            var model = svc.GetMessageById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMessage(int id)
        {
            var service = CreateMessageService();

            service.DeleteMessage(id);

            TempData["SaveResult"] = "Message was deleted";

            return RedirectToAction("Index");
        }

        //HELPER METHOD
        private MessageService CreateMessageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MessageService(userId);
            return service;
        }
    }
}