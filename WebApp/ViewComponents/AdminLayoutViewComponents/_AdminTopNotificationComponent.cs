using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.DTOs;

namespace WebApp.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminTopNotificationComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminTopNotificationComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7204/api/Notifications");
            if (response.IsSuccessStatusCode)
            {
                var notifications = await response.Content.ReadAsStringAsync();
                var JsonData = JsonConvert.DeserializeObject<List<NotificationResultDTO>>(notifications);
                return View(JsonData);
            }
            return View();
        }
    }
}
