namespace WebAPI.DTOs.MessageDTO
{
    public class ResultMessageDTO
    {
        public int MessageId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
    }
}
