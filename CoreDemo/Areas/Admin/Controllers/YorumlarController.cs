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

    public class YorumlarController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            var degerler = cm.ButunYorumlar();
            return View(degerler);
        }
        public IActionResult YayinDurumu(int id)
        {
            var deneme = cm.TGetByID(id);
            cm.TUpdate(deneme);
            return RedirectToAction("Index");
        }
    }
}
