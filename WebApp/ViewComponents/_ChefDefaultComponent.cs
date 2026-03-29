using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.DTOs.ChefDTO;

namespace WebApp.ViewComponents
{
    public class _ChefDefaultComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ChefDefaultComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7204/api/Chefs");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ChefResultDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
