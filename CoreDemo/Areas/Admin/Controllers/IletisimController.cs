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
    public class IletisimController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactRepository());

        public IActionResult Index()
        {
            var degerler = cm.GetList();
            return View(degerler);
        }
  
  
    }
}
