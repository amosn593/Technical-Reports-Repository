using DOMAIN.Models;

namespace DTO.Models
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
       
        public decimal Price { get; set; }
       
        
        public string Description { get; set; }
        
       
        public string ImageUrl { get; set; }
        
       
        public DateTime PostDate { get; set; }

        public Category Category { get; set; }
    }
}
