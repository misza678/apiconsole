﻿using System;
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
        [Column(TypeName ="nvarchar(20)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string LastName { get; set; }
      
        [Required]
     
        public string Email { get; set; }
      
        public string UserID { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int AddressID { get; set; }
        public Address Address { get; set; }
    }
}
