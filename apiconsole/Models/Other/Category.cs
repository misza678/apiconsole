using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace consolestoreapi.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        


    }
}
