using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCExercise.Models;

namespace MVCExercise
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContext;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _httpContext = httpContext;
        }

        public IActionResult Index()
        {
            _httpContext.HttpContext.Session.SetString("exampleKey", "123");
            return View();
        }

        public IActionResult BackGroundColor(HomeModel model)
        {
            var example = _httpContext.HttpContext.Session.GetString("exampleKey");
            ViewBag.example = example;

            ViewBag.VBColor = model.ViewBagColor;
            ViewData["VDColor"] = model.ViewDataColor;
            TempData["TDColor"] = model.TempDataColor;

            _httpContext.HttpContext.Response.Cookies.Append("ViewDataColor", model.ViewDataColor);
            _httpContext.HttpContext.Response.Cookies.Append("ViewBagColor", model.ViewBagColor);
            _httpContext.HttpContext.Response.Cookies.Append("TempDataColor", model.TempDataColor);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
