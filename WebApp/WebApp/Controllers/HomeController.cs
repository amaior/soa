using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View();
            /*var client = new HttpClient();
            var responseString = await client.GetStringAsync("https://localhost:44308/WeatherForecast");
            var response = JsonConvert.DeserializeObject<WeatherForecast>(responseString);
            return View(responseString);*/
        }
        //public async IActionResult Privacy()
        //{
        //    return View();
         //}
         [AllowAnonymous]
        public async Task<IActionResult> Privacy()
        {
            var client = new HttpClient();
            var responseString = await client.GetStringAsync("https://localhost:44308/WeatherForecast");
            var response = JsonConvert.DeserializeObject<WeatherForecast>(responseString);
            return View(responseString) ;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
