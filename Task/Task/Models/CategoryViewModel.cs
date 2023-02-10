using DB;
using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class CategoryViewModel
    {
        
        public int Id { get; set; }
        
        [Required]
        [Display(Name= "Category Name")]
        public string Name { get; set; }

        //public virtual ICollection<Property> Properties { get; set; }

        //public virtual ICollection<Device> Devices { get; set; }
    }
}
