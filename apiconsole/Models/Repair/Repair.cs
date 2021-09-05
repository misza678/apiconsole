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
            public int RepairId { get; set; }      
            public int ProductToViewId { get; set; }
            public ProductsToView ProductsToView { get; set; }
            public int ShippingMetodId { get; set; }
            public ShippingMetod ShippingMetod { get; set; }
            public int CustomerId { get; set; }
            public Customer Customer { get; set; }
            public int DefefectId { get; set; }
            public Defect Defect { get; set; }
            [Column(TypeName = "decimal(6,2)")]
            public decimal Price { get; set; }
            [Column(TypeName = "text")]
            public string Description { get; set; }
        }
    
}
