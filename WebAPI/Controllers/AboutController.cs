using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.DTOs.AboutDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly Context.ApiContext _context;
        private readonly IMapper _mapper;

        public AboutController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAbout()
        {
            var about = _context.Abouts.ToList();
            return Ok(_mapper.Map<List<ResultAboutDTO>>(about));
        }

        [HttpPost]
        public IActionResult AddAbout(CreateAboutDTO createAboutDTO)
        {
            var about = _mapper.Map<Entities.About>(createAboutDTO);
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return Ok("About has been added successfully!");
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var about = _context.Abouts.Find(id);
            _context.Abouts.Remove(about);
            _context.SaveChanges();
            return Ok("About has been deleted successfully!");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            var about = _mapper.Map<Entities.About>(updateAboutDTO);
            _context.Abouts.Update(about);
            _context.SaveChanges();
            return Ok("About has been updated successfully!");
        }

        [HttpGet("{id}")]
        public IActionResult GetAboutById(int id)
        {
            var about = _context.Abouts.Find(id);
            return Ok(_mapper.Map<GetByIdAboutDTO>(about));
        }
    }
}