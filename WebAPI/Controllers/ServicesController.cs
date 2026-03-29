using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.DTOs.ServiceDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ServicesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult ServicesList()
        {
            var values = _context.Services.ToList();
            return Ok(_mapper.Map<List<ServiceResultDTO>>(values));
        }

        [HttpDelete]
        public ActionResult ServiceDelete(int id)
        {
            var value = _context.Services.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Service has been delete successfully!");
        }

        [HttpPost]
        public ActionResult ServiceAdd(CreateServiceDTO createServiceDTO)
        {
            var service = _mapper.Map<Entities.Service>(createServiceDTO);
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Service has been added successfully!");
        }

        [HttpGet("{id}")]
        public ActionResult GetServiceById(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetByIdServiceDTO>(service));
        }

        [HttpPut]
        public ActionResult ServiceUpdate(UpdateServiceDTO updateServiceDTO)
        {
            var service = _mapper.Map<Entities.Service>(updateServiceDTO);
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Service has been updated successfully!");
        }
    }
}
