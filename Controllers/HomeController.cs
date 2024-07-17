using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Users users)
        {
            if (ModelState.IsValid) 
            {
                string filePath = Server.MapPath("~/App_Data/Пользователи.txt");
                string fileData = $"{users.FullName};{users.Address};{users.Phone};{users.Email};";

                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(fileData);

                }
                TempData["Message"] = "Данные успешно сохранены!";
                return RedirectToAction("Index");
            }
            return View("Index", users);
        }
    }
}