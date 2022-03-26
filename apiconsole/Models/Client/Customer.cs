using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace consolestoreapi.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
      
        public string UserID { get; set; }
        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }
        [Required]
        public int AddressID { get; set; }
        public Address Address { get; set; }
    }
   
}
