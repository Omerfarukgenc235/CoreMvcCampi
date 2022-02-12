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
    public class YazarlarController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
            var yazarlar = wm.GetList();
            return View(yazarlar);
        }
        [HttpGet]
        public IActionResult YazarDuzenle(int id)
        {
            var deger = wm.TGetByID(id);
            return View(deger);
        }
        [HttpPost]
        public IActionResult YazarDuzenle(Writer p)
        {
            p.WriterStatus = true;
            wm.TUpdate(p);
            return RedirectToAction("Index");
        }
        public IActionResult YazarYayin(int id)
        {
            var deger = wm.TGetByID(id);
            wm.YazarYayinDurumu(deger);
            return RedirectToAction("Index");         
        }
    }
}
