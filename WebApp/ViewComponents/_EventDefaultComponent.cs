using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.DTOs;

namespace WebApp.ViewComponents
{
    public class _EventDefaultComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _EventDefaultComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7204/api/EventSlides");
            if(response.IsSuccessStatusCode)
            {
                var jsonData= await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<EventResultDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
