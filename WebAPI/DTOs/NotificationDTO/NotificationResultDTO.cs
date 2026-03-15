namespace WebAPI.DTOs.NotificationDTO
{
    public class NotificationResultDTO
    {
        public int NotificationId { get; set; }
        public string Description { get; set; }
        public DateTime NotificationTime { get; set; }
        public string IconURL { get; set; }
        public bool IsRead { get; set; }
    }
}
