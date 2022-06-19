using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin
{
    [Area("Admin")]
    public class BildirimlerController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
       [HttpGet]
        public IActionResult Index()
        {
            var degerler = nm.GetList().OrderByDescending(x=>x.NotificationID).ToList();
            return View(degerler);
        }
        [HttpPost]
        public IActionResult Index(Notification p)
        {
            p.NotificationDate = DateTime.Now;
            p.NotificationStatus = true;
            nm.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult Sil(int id)
        {
            var deger = nm.TGetByID(id);
            nm.TDelete(deger);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            var deger = nm.TGetByID(id);
            return View(deger);
        }
        [HttpPost]
        public IActionResult Guncelle(Notification p)
        {
            nm.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
