using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class PropertiesValues
    {
        
        [Required]
        public string Values { get; set; }

        [ForeignKey("Device")]
        public int DeviceId { get; set; }
        public virtual Device Device { get; set; }

        [ForeignKey("property")]
        public int PropertyId { get; set; }
        public virtual Property property { get; set; }

    }
}
