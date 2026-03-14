using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.DTOs.ChefDTO;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly Context.ApiContext _context;
        private readonly IMapper _mapper;

        public ChefsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ChefList()
        {
            var values = _context.Chefs.ToList();
            return Ok(_mapper.Map<List<ChefResultDTO>>(values));
        }

        [HttpPost]
        public IActionResult AddChef(ChefCreateDTO chefCreateDTO)
        {
            var chef = _mapper.Map<Chef>(chefCreateDTO);
            var value =_context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Chef has been added successfully!");
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var value = _context.Chefs.Find(id);
            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return Ok("Chef has been deleted successfully!");
        }

        [HttpGet("{id}")]
        public IActionResult GetChef(int id)
        {
            var value = _context.Chefs.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            var value = _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Chef has been updated successfully!");

        }
    }
}
