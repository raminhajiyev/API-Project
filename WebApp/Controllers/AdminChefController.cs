using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.DTOs;
using WebApp.DTOs.ChefDTO;

namespace WebApp.Controllers
{
    public class AdminChefController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminChefController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ChefList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7204/api/Chefs");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ChefResultDTO>>(jsonData);
                return View(value);
            }
            return View();
        }


        public async Task<IActionResult> DeleteChef(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7204/api/Chefs?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ChefList");
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddChef()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddChef(CreateChefDTO createChefDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createChefDTO);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7204/api/Chefs", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ChefList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateChef(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7204/api/Chefs/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateChefDTO>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateChef(UpdateChefDTO updateChefDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateChefDTO);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7204/api/Chefs", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ChefList");
            }
            return View();
        }
    }
}