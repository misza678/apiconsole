using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace consolestoreapi.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        [MaxLength(45)]
        public string City { get; set; }
        [MaxLength(6)]
        public string PostalAddress { get; set; }
        [MaxLength(45)]
        public string Street { get; set; }
        [MaxLength(5)]
        public string HouseNumber { get; set; }
        public int FlatNumber { get; set; }

    }
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(t => t.City).NotEmpty().WithMessage("City can't be empty").MaximumLength(45).WithMessage("City max lenght is 45");
            RuleFor(t => t.PostalAddress).NotEmpty().WithMessage("PostalAddress can't be empty").MaximumLength(6).WithMessage("PostalAddress max lenght is 6");
            RuleFor(t => t.Street).NotEmpty().WithMessage("Street can't be empty").MaximumLength(45).WithMessage("Street max lenght is 45");
            RuleFor(t => t.HouseNumber).NotEmpty().WithMessage("HouseNumber can't be empty").MaximumLength(5).WithMessage("HouseNumber max lenght is 5");
            RuleFor(t => t.FlatNumber).NotEmpty().WithMessage("FlatNumber can't be empty").GreaterThanOrEqualTo(1).WithMessage("FlatNumber must be greather or equal 1");
        }

    }
}
