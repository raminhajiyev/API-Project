using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.DTOs;

namespace WebApp.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminTopMessageComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminTopMessageComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7204/api/Messages/IsReadFalse");
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<MessageUnreadResultDTO>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
