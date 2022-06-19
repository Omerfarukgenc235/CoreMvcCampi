using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutRepository());

        [HttpGet]

        public IActionResult Index()
        {
            var deger = abm.TGetByID(1);
            TempData["id"] = 1;
            return View(deger);
        }
        [HttpPost]
        public IActionResult Index(About p)
        {
            p.AboutID = (int)TempData["id"];
            p.AboutStatus = true;
            abm.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
