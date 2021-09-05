using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace consolestoreapi.Models
{
    public class Company
    {

        [Key]
        public int CompanyId { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }
    }
}
