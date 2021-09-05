using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiconsole.Models
{
    public class ShippingMetod
    {

        [Key]
        public int ShippingMetodId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public string PhotoSRC { get; set; }
    }
}
