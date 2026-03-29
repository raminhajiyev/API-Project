using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.DTOs.TestimonialDTO;

namespace WebApp.ViewComponents
{
    public class _TestimonialDefaultComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialDefaultComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7204/api/Testimonials");
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TestimonialResultDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
