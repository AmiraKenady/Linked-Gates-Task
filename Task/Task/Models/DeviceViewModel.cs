using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class DeviceViewModel
    {
        
        [Required]
        public string Name { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public string memo { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
