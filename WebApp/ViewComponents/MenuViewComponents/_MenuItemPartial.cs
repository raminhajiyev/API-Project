using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.DTOs;

namespace WebApp.ViewComponents.MenuViewComponents
{
    public class _MenuItemPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _MenuItemPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7204/api/Products");
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ProductResultDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
