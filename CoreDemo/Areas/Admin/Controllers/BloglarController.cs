using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class BloglarController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var degerler = bm.GetBlogListWithCategoryandWriter();
            return View(degerler);
        }
        public IActionResult BlogListesi()
        {
            return View();
        }
        public IActionResult BlogYayin(int id)
        {
            var blogdurum = bm.TGetByID(id);
            bm.TUpdateDurum(blogdurum);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult BlogDuzenleme(int id)
        {
            var degerler = bm.TGetByID(id);
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryvalue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.cv = categoryvalue;
            return View(degerler);
        }
        [HttpPost]
        public IActionResult BlogDuzenleme(Blog p)
        {
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
