using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ch04MultiPageAmbroson.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Ch04MultiPageAmbroson.Controllers
{
    public class HomeController : Controller
    {
        private PhoneContext Context { get; set; }

        public HomeController(PhoneContext ctx)
        {
            Context = ctx;
        }

        public IActionResult Index()
        {
            var phone = Context.PhoneContacts.Include(p => p.Contact).OrderBy(p => p.Name).ToList();
            return View(phone);
        }
    }
}
