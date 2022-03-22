using apiconsole.Models.Other;
using apiconsole.Models.Repair;
using consolestoreapi.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiconsole.Models.CollectionCentre
{
    public class CollectionItem
    {
        [Key]
        public int CollectionItemID { get; set; }
        public ICollection<Images> Images { get; set; }
        [Required]
        public int ModelID { get; set; }
        public Model Model { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public bool WithController { get; set; }
        public int StatusID { get; set; }
        public Status Status { get; set; }
    }
    public class CollectionItemValidator : AbstractValidator<CollectionItem>
    {
        public CollectionItemValidator()
        {
            RuleFor(t => t.ModelID).NotEmpty().WithMessage("ModelID can't be empty").GreaterThanOrEqualTo(1).WithMessage("ModelID must be greather or equal 1");
            RuleFor(t => t.WithController).NotEmpty().WithMessage("WithController can't be empty");
            RuleFor(t => t.CustomerID).NotEmpty().WithMessage("CustomerID can't be empty").GreaterThanOrEqualTo(1).WithMessage("CustomerID must be greather or equal 1");
            RuleFor(t => t.StatusID).NotEmpty().WithMessage("StatusID can't be empty").GreaterThanOrEqualTo(1).WithMessage("StatusID must be greather or equal 1");
        }

    }
}   
