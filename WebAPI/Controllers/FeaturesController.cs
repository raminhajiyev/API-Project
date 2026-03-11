using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.DTOs.FeatureDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public FeaturesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDTO>>(values));
        }

        [HttpPost]
        public IActionResult AddFeature(CreateFeatureDTO createFeatureDTO)
        {
            var feature = _mapper.Map<Entities.Feature>(createFeatureDTO);
            _context.Features.Add(feature);
            _context.SaveChanges();
            return Ok("Feature has been added successfully!");
        }

        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _context.Features.Find(id);
            return Ok(_mapper.Map<GetByIdFeatureDTO>(value));
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Feature has been deleted successfully!");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            var feature = _mapper.Map<Entities.Feature>(updateFeatureDTO);
            var value = _context.Features.Update(feature);
            _context.SaveChanges();
            return Ok("Feature has been updated successfully!");

        }
    }
}
