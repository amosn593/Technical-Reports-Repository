using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }
        [Required]
        [Precision(10, 2)]
        public decimal Price { get; set; }
        [Required]
        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "varchar(400)")]
        public string ImageUrl { get; set; }
        [Required]
        [Precision(3)]
        public DateTime PostDate { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; }
    }
}
