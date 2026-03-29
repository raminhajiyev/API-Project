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

        [HttpDelete]
        public ActionResult TestimonialDelete(int id)
        {
            var value = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public ActionResult TestimonialAdd(CreateTestimonialDTO createTestimonialDTO)
        {
            var testimonial = _mapper.Map<Entities.Testimonial>(createTestimonialDTO);
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return Ok("Testimonial has been added successfully!");
        }
        [HttpGet("{id}")]
        public ActionResult GetTestimonialById(int id)
        {
            var testimonial = _context.Testimonials.Find(id);
            if (testimonial == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetByIdTestimonialDTO>(testimonial));
        }

        [HttpPut]
        public ActionResult TestimonialUpdate(UpdateTestimonialDTO updateTestimonialDTO)
        {
            var testimonial = _mapper.Map<Entities.Testimonial>(updateTestimonialDTO);
            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return Ok("Testimonial has been updated successfully!");
        }

    }
}
