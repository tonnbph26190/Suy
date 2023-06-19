using _1.DATA.Model;
using _3.View.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _3.View.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var api = "https://localhost:7174/api/SinhVien";
            var res= await _httpClient.GetFromJsonAsync<List<SinhVien>>(api);
            return View(res);
        }

        
        public async Task<IActionResult> Delete( string id)
        {
            var api = "https://localhost:7174/api/SinhVien/"+id;
             await _httpClient.DeleteAsync(api);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Create(SinhVien sinhVien) 
         {
            if (HttpMethods.IsGet(HttpContext.Request.Method))
            {
                return View();
            }
            var api = "https://localhost:7174/api/SinhVien";
            if (ModelState.IsValid)
            {
                var res = await _httpClient.PostAsJsonAsync<SinhVien>(api, sinhVien);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
            }
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