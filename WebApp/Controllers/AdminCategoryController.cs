using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.DTOs.CategoryDTO;

namespace WebApp.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CategoryList() 
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7204/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<CategoryResultDTO>>(jsonData);
                return View(jsonData);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddCategory() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CreateCategoryDTO createCategoryDTO) 
        {
            // Logic to add category using createCategoryDTO
            return RedirectToAction("CategoryList");
        }
    }
}
