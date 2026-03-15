using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.DTOs.NotificationDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public NotificationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetNotifications()
        {
            var notifications = _context.Notifications.ToList();
            var notificationDTOs = _mapper.Map<List<DTOs.NotificationDTO.NotificationResultDTO>>(notifications);
            return Ok(notificationDTOs);
        }

        [HttpPost]
        public IActionResult CreateNotification (CreateNotificationDTO createNotificationDTO)
        {
            var notification = _mapper.Map<Entities.Notification>(createNotificationDTO);
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            return Ok("Notification created successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        { 
            var notification = _context.Notifications.Find(id);
            _context.Notifications.Remove(notification);
            _context.SaveChanges();
            return Ok("Notification deleted successfully");

        }


    }
}
