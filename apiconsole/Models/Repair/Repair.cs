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
    
    public class RepairValidator : AbstractValidator<Repair>
    {
        public RepairValidator()
        {
            RuleFor(t => t.ModelID).NotEmpty().WithMessage("ModelID can't be empty").GreaterThanOrEqualTo(1).WithMessage("ModelID must be greather or equal 1");
            RuleFor(t => t.ShippingMetodID).NotEmpty().WithMessage("ShippingMetodID can't be empty").GreaterThanOrEqualTo(1).WithMessage("ShippingMetodID must be greather or equal 1");
            RuleFor(t => t.CustomerID).NotEmpty().WithMessage("CustomerID can't be empty").GreaterThanOrEqualTo(1).WithMessage("CustomerID must be greather or equal 1");
            RuleFor(t => t.DefectID).NotEmpty().WithMessage("DefectID can't be empty").GreaterThanOrEqualTo(1).WithMessage("DefectID must be greather or equal 1");
            RuleFor(t => t.StatusID).NotEmpty().WithMessage("StatusID can't be empty").GreaterThanOrEqualTo(1).WithMessage("StatusID must be greather or equal 1");
        }
       
    }


}
