using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Task.Models
{
    public class PropertiesValuesViewModel
    {
        [Required]
        public int propertyId { get; set; }
        public int DeviceId { get; set; }
        public string values  { get; set; }
       
        //[Display(Name = "DeviceName")]
        //[Required(ErrorMessage = "Device Name is Required")]
        //public string DeviceName { get; set; }
        //[Required(ErrorMessage = "AcquisitionDate is Required")]
        //[Display(Name = "DeviceAcquisitionDate")]
        //public DateTime DeviceAcquisitionDate { get; set; }
        //[Display(Name = "DeviceMemo")]
        //[Required(ErrorMessage = "Device Memo is Required")]
        //public string DeviceMemo { get; set; }
        //[Display(Name = "Category Name")]
        //[Required(ErrorMessage ="please select category")]
        //public string CategoryName { get; set; }
        //public int CategoryId { get; set; }



    }
}
