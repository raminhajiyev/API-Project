namespace WebApp.DTOs.ServiceDTO
{
    public class GetByIdServiceDTO
    {
        public int ServiceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconURL { get; set; }
    }
}
