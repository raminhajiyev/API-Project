using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.DTOs.EventSlideDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventSlidesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public EventSlidesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult EventList()
        {
            var values = _context.EventSlides.ToList();
            return Ok(_mapper.Map<List<EventResultDTO>>(values));

        }

        [HttpPost]
        public ActionResult AddEventSlide(CreateEventDTO createEventDTO)
        {
            var newEventSlide = _mapper.Map<Entities.EventSlide>(createEventDTO);
            _context.EventSlides.Add(newEventSlide);
            _context.SaveChanges();
            return Ok("Event has been added successfully");

        }
    }
}
