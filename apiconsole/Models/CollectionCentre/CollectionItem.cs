using consolestoreapi.Models;
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
        public int CollectionItemId { get; set; }
        public int ImageId { get; set; }
        public ICollection<Images> Images { get; set; }  
        public int ProductToViewId { get; set; }
        public ProductsToView ProductsToView { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public bool WithController { get; set; }
    }
}   
