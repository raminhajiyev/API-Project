using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.DTOs.AboutDTO;
using WebApp.DTOs.CategoryDTO;

namespace WebApp.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AboutList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7204/api/About");
            if (response.IsSuccessStatusCode)
            {
                var aboutInfo = await response.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(aboutInfo);
                return View(jsonData);
            }

            return View();

        }

        //public async Task<IActionResult> DeleteAbout(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var response = await client.DeleteAsync($"https://localhost:7204/api/About/{id}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("AboutList");
        //    }
        //    return View();
        //}

        public async Task<IActionResult> DeleteAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7204/api/About?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("AboutList");
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAbout(CreateAboutDTO createAboutDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAboutDTO);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7204/api/About", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("AboutList");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7204/api/About/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAboutDTO>(jsonData);
                return View(value);
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAboutDTO);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7204/api/About", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("AboutList");
            }
            return View();
        }
    }
}
