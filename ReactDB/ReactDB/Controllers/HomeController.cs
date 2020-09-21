using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactDB.Models;

namespace ReactDB.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<WeatherModel> _comments;

        static HomeController()
        {
            _comments = new List<WeatherModel>
            {
                new WeatherModel
                {
                    Id = 1,
                    City = "Los Angeles",
                    DateTime = "2020 Sometime",
                    Temp = 204.5,
                    TempFeel = 213.8,
                    Weather = "Clouds"
                },
            };
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_comments);
        }
    }
}
