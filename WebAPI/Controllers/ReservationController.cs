using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly Context.ApiContext _context;
        private readonly IMapper _mapper;

        public ReservationController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetReservation()
        {
            var reservation = _context.Reservations.ToList();
            return Ok(_mapper.Map<List<DTOs.ReservationDTO.ReservationResultDTO>>(reservation));
        }

        [HttpDelete]
        public IActionResult DeleteReservation(int id)
        {
            var value = _context.Reservations.Find(id);
            _context.Reservations.Remove(value);
            _context.SaveChanges();
            return Ok("Reservation has been deleted successfully!");
        }

        [HttpPost]
        public IActionResult AddReservation(DTOs.ReservationDTO.CreateReservationDTO createReservationDTO)
        {
            var reservation = _mapper.Map<Entities.Reservation>(createReservationDTO);
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return Ok("Reservation has been added successfully!");
        }

        [HttpPut]
        public IActionResult UpdateReservation(DTOs.ReservationDTO.UpdateReservationDTO updateReservationDTO)
        {
            var reservation = _mapper.Map<Entities.Reservation>(updateReservationDTO);
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
            return Ok("Reservation has been updated successfully!");
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);
            return Ok(_mapper.Map<DTOs.ReservationDTO.GetByIdReservationDTO>(reservation));
        }
    }
}
