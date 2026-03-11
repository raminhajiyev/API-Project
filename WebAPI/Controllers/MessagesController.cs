using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.DTOs.MessageDTO;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IValidator<Message> _validator;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public MessagesController(IValidator<Message> validator, ApiContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList(Message message)
        {
            var messages = _context.Messages.ToList();
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public IActionResult MessageDetail(int id)
        {
            var value = _context.Messages.Find(id);
            return Ok(_mapper.Map<GetByIdMessageDTO>(value));
        }

        [HttpPost]
        public IActionResult CreateMessage(Message message)
        {
            var validationResult = _validator.Validate(message);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x=>x.ErrorMessage));
            }
            _context.Messages.Add(message);
            _context.SaveChanges();
            return Ok("Message has been created successfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            if (value == null)
            {
                return NotFound("Message not found.");
            }
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("Message has been deleted successfully!");
        }
         

    }
}
