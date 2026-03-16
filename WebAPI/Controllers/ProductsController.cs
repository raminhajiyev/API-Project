using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.DTOs.CategoryDTO;
using WebAPI.DTOs.ProductDTO;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ProductsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductListWithCategory()
        {
            var values = _context.Products.Include(x => x.Category).ToList();
            return Ok(_mapper.Map<List<ProductResultWithCategoryDTO>>(values));
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductDTO createProductDTO)
        {
            var product = _mapper.Map<Entities.Product>(createProductDTO);
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok("Product has been added successfully!");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return Ok("Product has been deleted successfully!");
        }

        [HttpGet("GetProductWithCategory")]
        public IActionResult GetProductWithCategory() {
            var value = _context.Products.Include(x => x.Category).ToList();
            return Ok(_mapper.Map<List<ProductResultWithCategoryDTO>>(value));
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            return Ok(_mapper.Map<GetByIdProductDTO>(_context.Products.Find(id)));
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDTO updateProductDTO)
        {

            var value = _mapper.Map<Product>(updateProductDTO);
            _context.Products.Update(value);
            _context.SaveChanges();
            return Ok("Product has been updated successfully!");
        }
    } }
