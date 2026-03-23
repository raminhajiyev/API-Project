namespace WebApp.DTOs.FeatureDTO
{
    public class FeatureByIdDTO
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string VideoURL { get; set; }
        public string ImageURL { get; set; }
    }
}
