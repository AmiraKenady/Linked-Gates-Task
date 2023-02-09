using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class CategoryViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
