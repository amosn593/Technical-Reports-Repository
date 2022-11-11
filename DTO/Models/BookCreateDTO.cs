using DOMAIN.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DTO.Models
{
    public class BookCreateDTO
    {
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "varchar(400)")]
        public IFormFile ImageFile { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
    }
}
