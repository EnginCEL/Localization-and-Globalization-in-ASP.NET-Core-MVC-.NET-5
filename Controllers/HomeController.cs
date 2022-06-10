using LocalizationGlobalization.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizationGlobalization.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHtmlLocalizer<HomeController> _htmlLocalizer;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger , IHtmlLocalizer<HomeController> htmlLocalizer)
        {
            _logger = logger;
            _htmlLocalizer = htmlLocalizer;
        }

      

        public IActionResult Index()
        {
            var test = _htmlLocalizer["HelloWorld"];
            ViewData["HelloWorld"] = test;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CultureManagement(string culture, string ReturnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(30)
        }) ;

            return LocalRedirect(ReturnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
