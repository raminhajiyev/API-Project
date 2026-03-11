namespace WebAPI.DTOs.MessageDTO
{
    public class CreateMessageDTO
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
    }
}
