using consolestoreapi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiconsole.Models.Repair
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        [Required]
        public string Name { get; set; }
        [Required]
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        [Required]
        public string PhotoSRC { get; set; }
        public ICollection<Model> Model { get; set; }
    }
}