using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class PropertyViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


    }
}
