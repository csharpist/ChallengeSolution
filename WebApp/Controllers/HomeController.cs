using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DatabaseLibrary.Conrete.Dto;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult CreateUser()
        {
            return View(new UserDto());
        }

        public ActionResult Users()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadCsv()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadCsv(HttpPostedFileBase file)
        {

            return RedirectToAction("Users");
        }

    }
}