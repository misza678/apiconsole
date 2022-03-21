using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace consolestoreapi.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        [MaxLength(45)]
        public string City { get; set; }
        [MaxLength(45)]
        public string PostalAddress { get; set; }
        [MaxLength(45)]
        public string Street { get; set; }
        [MaxLength(5)]
        public string HouseNumber { get; set; }
        public int FlatNumber { get; set; }

    }
}
