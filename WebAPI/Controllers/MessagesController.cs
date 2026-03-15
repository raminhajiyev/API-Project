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
        private readonly IValidator<CreateMessageDTO> _validator;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public MessagesController(IValidator<CreateMessageDTO> validator, ApiContext context, IMapper mapper)
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
        public IActionResult CreateMessage(CreateMessageDTO createMessageDTO)
        {
            var validationResult = _validator.Validate(createMessageDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x=>x.ErrorMessage));
            }
            _context.Messages.Add(_mapper.Map<Message>(createMessageDTO));
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

        [HttpGet("IsReadFalse")]
        public IActionResult GetUnreadMessages()
        {
            var unreadMessages = _context.Messages.Where(m => m.IsRead == false).ToList();
            return Ok(_mapper.Map<List<ResultMessageDTO>>(unreadMessages));
        }
         

    }
}
