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
        public int DefectId { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string Name { get; set; }
        public int DefectType { get; set; }     
    }
}
 