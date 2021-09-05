using apiconsole.Models.Repair;
using consolestoreapi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiconsole.Models
{
    public class ProductsToView
    {
        [Key]
        public int ModlesToViewId { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string Name { get; set; }
        public int MainProductsToViewId { get; set; }
        public MainProductsToView MainProductsToView { get; set; }
        public string PhotoSRC { get; set; }
        public string DefectType { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
