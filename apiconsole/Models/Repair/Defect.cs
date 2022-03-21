using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiconsole.Models.Repair
{
    public class Defect
    {

        [Key]
        public int DefectID { get; set; }
        [MaxLength(60)]
        [Required]
        public string Name { get; set; }  
        public ICollection<Model> Models { get; set; }
        public List<DefectModel> DefectModels { get; set; }
    }
}
 