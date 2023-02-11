using DB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    public class DeviceViewModel
    {
        [Display(Name = "Device Name")]
        [Required(ErrorMessage ="Device Name is Required")]
        public string DeviceName { get; set; }
        [Display(Name = "Acquisition Date")]
        [Required(ErrorMessage = "AcquisitionDate is Required")]
        public DateTime DeviceAcquisitionDate { get; set; }
        [Display(Name = "Memo")]
        [Required(ErrorMessage = "Device Memo is Required")]
        public string DeviceMemo { get; set; }
        
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Please Select Category")]
        public int CategoryId { get; set; }
    }
}
