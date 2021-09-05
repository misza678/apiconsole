using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace consolestoreapi.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int OrdersProductId { get; set; }
        public OrdersProducts OrdersProducts { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal FullPrice { get; set; }
    }
}
