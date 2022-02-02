using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IActionResult InBox()
        {
            var values = mm.GetInboxByWriter(1);
            return View(values);
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var value = mm.TGetByID(id);          
            return View(value);
        }
     
    }
}
