using apiconsole.Models.Repair;
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
        public int CompanyID { get; set; }
        [MaxLength(25)]
        [Required]
        public string Name { get; set; }

    }
}
