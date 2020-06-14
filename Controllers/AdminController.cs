using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asteria.Interface;
using Asteria.Models;
using Asteria.Models.Admin;
using Asteria.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asteria.Controllers
{
    public class AdminController : Controller
    {

       
        private readonly IData data;
        public AdminController()
        {
            
            data = new DataApi();
        }

        // GET: Admin 
        /// <summary>
        /// Открывает страницу для входа
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        // GET: Admin/Details/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Route("lg")]
        public async Task< ActionResult> Login(UserLogin user)
        {
            var  res =await Task.Run(()=> data.Login(user));
           
            if(res.Value.StartsWith('4')) { return View(); }
            else { return Redirect("~/Admin/Panel"); }
        }
        [Route("out")]
        public ActionResult Logout()
        {
            data.Logout();
             return Redirect("~/Home/Index");
        }

        // GET: Admin/
        public IActionResult Panel()
        {
            return View();
        }


        public IActionResult Records()
        {
            return View(data.GetRecords());
        }

        public IActionResult GetRecords(int id)
        {
           var r = data.GetRecords();
            return Json(r);
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeRecord(RecordsDTO rec)
        {
            try
            {

                var res = data.PutRecord(rec, rec.Id);
                return RedirectToAction("Panel", "Admin");
            }
            catch(Exception e)
            {
                return RedirectToAction("Panel", "Admin");
            }
        }

    }
}