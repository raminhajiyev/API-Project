using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.DTOs.TestimonialDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public TestimonialsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult TestimonialList()
        {
            var value = _context.Testimonials.ToList();
            return Ok(_mapper.Map<List<TestimonialResultDTO>>(value));
        }

    }
}
