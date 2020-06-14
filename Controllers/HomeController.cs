using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asteria.Models;
using Asteria.Interface;

namespace Asteria.Controllers
{
    public class HomeController : Controller
    {
        private readonly IData data;

        public HomeController()
        {
            data = new DataApi();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        

        public IActionResult Booking()
        {
            
            
            return View();
        }

        /// <summary>
        ///  Обработка формы
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="wk_select"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddClient(string spec, string name, string phone,string date, string time,string wk_select, string message)
        {
            var data = new DataHelpercs();
            
           data.FormProcessing( name,  phone,  date,  time,  wk_select,  message, spec);
           return Redirect("~/Home/Booking/");
        }

        [HttpGet]
        public IActionResult GetSheets(string date, string spec)
        {
            var data = new DataHelpercs();
            var d = data.CreateSheets(date, spec);
            return Json(d);
        }

        [HttpGet]
        public IActionResult GetRecords(string date, string spec)
        {
            
            var d = data.GetRecords(date, spec);
            return Json(d);
        }

        [HttpGet]
        
        public IActionResult GetRecordsData(string date)
        {

            var d = data.GetRecords(date);
            return Json(d);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
