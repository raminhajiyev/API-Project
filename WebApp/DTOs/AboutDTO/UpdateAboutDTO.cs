namespace WebApp.DTOs.AboutDTO
{
    public class UpdateAboutDTO
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string ImageURL { get; set; }
        public string VideoCoverURL { get; set; }
        public string VideoURL { get; set; }
    }
}
