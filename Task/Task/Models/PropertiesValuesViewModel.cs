using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Task.Models
{
    public class PropertiesValuesViewModel
    {
        [Required]
        public int propertyId { get; set; }
        [Required]
        public int DeviceId { get; set; }
        public string values  { get; set; }
       


    }
}
