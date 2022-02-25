﻿using apiconsole.Models.Repair;
using consolestoreapi.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiconsole.Models.CollectionCentre
{
    public class CollectionItem
    {
        [Key]
        public int CollectionItemID { get; set; }
        public int ImageID { get; set; }
        public ICollection<Images> Images { get; set; }
        [Required]
        public int ProductID { get; set; }
        public Product Product { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public bool WithController { get; set; }
    }
}   
