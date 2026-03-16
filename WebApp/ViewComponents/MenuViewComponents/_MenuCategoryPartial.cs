using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.DTOs.CategoryDTO;

namespace WebApp.ViewComponents.MenuViewComponents
{
    public class _MenuCategoryPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _MenuCategoryPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7204/api/Categories");
            if (response.IsSuccessStatusCode)
            {
               var jsonData = await response.Content.ReadAsStringAsync();
                var values =JsonConvert.DeserializeObject<List<CategoryResultDTO>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
