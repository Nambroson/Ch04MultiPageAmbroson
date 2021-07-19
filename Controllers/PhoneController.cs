using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ch04MultiPageAmbroson.Models;

namespace Ch04MultiPageAmbroson.Controllers
{
    public class PhoneController : Controller
    {
        private PhoneContext Context { get; set; }

        public PhoneController(PhoneContext ctx)
        {
            Context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Type = Context.Contacts.OrderBy(t => t.Name).ToList();
            return View("Edit", new Phone());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Type = Context.Contacts.OrderBy(t => t.Name).ToList();
            var phone = Context.PhoneContacts.Find(id);
            return View(phone);
        }

        [HttpPost]
        public IActionResult Edit(Phone phone)
        {
            if (ModelState.IsValid)
            {
                if (phone.PhoneId == 0)
                    Context.PhoneContacts.Add(phone);
                else
                    Context.PhoneContacts.Update(phone);
                Context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (phone.PhoneId == 0) ? "Add" : "Edit";
                ViewBag.Type = Context.Contacts.OrderBy(t => t.Name).ToList();
                return View(phone);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var phone = Context.PhoneContacts.Find(id);
            return View(phone);
        }

        [HttpPost]
        public IActionResult Delete(Phone phone)
        {
            Context.PhoneContacts.Remove(phone);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}