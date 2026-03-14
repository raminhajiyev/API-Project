namespace WebAPI.Entities
{
    public class EventSlide
    {
        public int EventSlideId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public bool Status { get; set; }
        public decimal Price { get; set; }
    }
}
