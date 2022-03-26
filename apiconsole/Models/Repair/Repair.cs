using apiconsole.Models;
using apiconsole.Models.Other;
using apiconsole.Models.Repair;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace consolestoreapi.Models
{
    
        public class Repair
        {
        [Key]
        public int RepairID { get; set; }
        [Required]
        public int ModelID { get; set; }
        public Model Model { get; set; }
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
        public int StatusID { get; set; }
        public Status Status { get; set; }
        }
    
  


}
