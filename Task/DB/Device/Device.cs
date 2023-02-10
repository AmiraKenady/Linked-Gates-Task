using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Device
    {
        public Device() 
        {
            Property = new List<Property>();
            PropertyValues = new List<PropertiesValues>();
        } 
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public string Memo { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<PropertiesValues> PropertyValues { get; set; }
        public virtual ICollection<Property> Property { get; set; }

    }
}
