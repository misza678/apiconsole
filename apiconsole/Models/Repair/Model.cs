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
    public class Model
    {
        [Key]
        public int ModelID { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhotoSRC { get; set; }
        [Required]
        public int ProductID { get; set; }
        public Product Product { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public ICollection<Defect> Defects { get; set; }
        public List<DefectModel> DefectModels { get; set; }
    }
}
