using WebAPI.Entities;

namespace WebAPI.DTOs.CategoryDTO
{
    public class CategoryResultDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
