using consolestoreapi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiconsole.Models.Repair
{
    public class MainProductsToView
    {
        [Key]
        public int ProductsToViewId { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string PhotoSRC { get; set; }

       
    }
}
