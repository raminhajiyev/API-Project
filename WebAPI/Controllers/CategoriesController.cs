using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.DTOs.CategoryDTO;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly Context.ApiContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return Ok(_mapper.Map<List<CategoryResultDTO>>(values));
        }

        //[HttpGet("GetCategoryListWithProducts")]
        //public IActionResult GetCategoryListWithProducts()
        //{
        //    var values = _context.Categories.Include(x => x.Products).
        //        Select(c => new CategoryResultDTO
        //        {
        //            CategoryId = c.CategoryId,
        //            CategoryName = c.CategoryName,
        //            Products = c.Products
        //        })
        //        .ToList();
        //    return Ok(values);
        //}

        [HttpPost]
        public IActionResult AddCategory(CreateCategoryDTO createCategoryDTO)
        {
            var category = _mapper.Map<Category>(createCategoryDTO);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Category has been added successfully!");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Category has been deleted successfully!");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _context.Categories
                .Include(c => c.Products)
                .FirstOrDefault(c => c.CategoryId == id);

            if (value == null)
                return NotFound();

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            var value = _mapper.Map<Category>(updateCategoryDTO);
            _context.Categories.Update(value);
            _context.SaveChanges();
            return Ok("Category has been updated successfully!");

        }

    }
}