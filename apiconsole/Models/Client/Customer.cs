using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace consolestoreapi.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
      
        public string UserID { get; set; }
        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }
        [Required]
        public int AddressID { get; set; }
        public Address Address { get; set; }
    }
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("Name can't be empty").MaximumLength(20).WithMessage("Name max lenght is 20");
            RuleFor(t => t.LastName).NotEmpty().WithMessage("LastName can't be empty").MaximumLength(50).WithMessage("LastName max lenght is 50");
            RuleFor(t => t.Email).NotEmpty().WithMessage("Email can't be empty").MaximumLength(100).WithMessage("Email max lenght is 100");
            RuleFor(t => t.Phone).NotEmpty().WithMessage("StatusID can't be empty").MaximumLength(12).WithMessage("Phone number max lenght is 12");
            RuleFor(t => t.AddressID).NotEmpty().WithMessage("AddressID can't be empty").GreaterThanOrEqualTo(1).WithMessage("AddressID must be greather or equal 1");
        }

    }
}
