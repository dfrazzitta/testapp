using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using testapp.Models;

namespace testapp.Controllers
{
    public class HomeController : Controller
    {
        // git 1
        // git 2
        // git 3
        // git 4
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<string> Privacy()
        {

            using (var client1 = new System.Net.Http.HttpClient())
            {
                // Call *mywebapi*, and display its response in the page
                var request = new System.Net.Http.HttpRequestMessage();
                // request.RequestUri = new Uri("http://kapi/WeatherForecast/saveme"); // ASP.NET 3 (VS 2019 only)
                string uriApi = "https://k8svc.net:5001/weatherforecast/";
                request.RequestUri = new Uri(uriApi); // ASP.NET 3 (VS 2019 only)
                // remember to localhost: any multi-container pods
                // request.RequestUri = new Uri("http://kapi/api/KubernetesSystem/GetSystemData"); // ASP.NET 3 (VS 2019 only)
                //request.RequestUri = new Uri("http://kapi/api/WeatherForecast/"); // ASP.NET 2.x
                var response = await client1.SendAsync(request);
                var resp = await response.Content.ReadAsStringAsync();
                return resp;
            }


            return "";
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}