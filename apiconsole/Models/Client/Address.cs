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
        [Column(TypeName = "nvarchar(45)")]
        public string City { get; set; }
        [Column(TypeName = "nvarchar(6)")]
        public string PostalAddress { get; set; }
        [Column(TypeName = "nvarchar(45)")]
        public string Street { get; set; }
        [Column(TypeName = "nvarchar(5)")]
        public string HouseNumber { get; set; }
        public int FlatNumber { get; set; }

    }
}
