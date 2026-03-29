using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.DTOs.ReservationDTO;

namespace WebApp.Controllers
{
    public class AdminReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ReservationList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7204/api/Reservation");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ReservationResultDTO>>(jsonData);
                return View(value);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddReservation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(CreateReservationDTO createReservationDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDTO);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7204/api/Reservation", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ReservationList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7204/api/Reservation?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ReservationList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7204/api/Reservation/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateReservationDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservation(UpdateReservationDTO updateReservationDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateReservationDTO);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7204/api/Reservation", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ReservationList");
            }
            return View();
        }
    }
}
