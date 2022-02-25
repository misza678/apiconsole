using apiconsole.Models;
using apiconsole.Models.Repair;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace consolestoreapi.Models
{
    
        public class Repair
        {
            [Key]
            public int RepairID { get; set; }
        [Required]
        public int ProductID { get; set; }
            public Product Product { get; set; }
        [Required]
        public int ShippingMetodID { get; set; }
            public ShippingMetod ShippingMetod { get; set; }
        [Required]
        public int CustomerID { get; set; }
            public Customer Customer { get; set; }
        [Required]
        public int DefectID { get; set; }
            public Defect Defect { get; set; }
            [Column(TypeName = "decimal(6,2)")]
            public decimal Price { get; set; }
            [Column(TypeName = "text")]
            public string Description { get; set; }
        }
    
}
