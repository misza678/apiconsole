using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiconsole.Models.CollectionCentre
{
    public class Images
    {
        [Key]
        public int ImageID { get; set; }
        [Required]
        public string ImageSrc { get; set; }
        public CollectionItem CollectionItem { get; set; }
    }
}
