using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.DTOs.ProductDTO;

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
    }
}
