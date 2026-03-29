namespace WebAPI.DTOs.ChefDTO
{
    public class GetByIdChefDTO
    {
        public int ChefId { get; set; }
        public string Fullname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}
