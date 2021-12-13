using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiconsole.Models.CollectionCentre;
namespace apiconsole.Models.CollectionCentre
{
    public class CollectionImages
    {
        public List<IFormFile> Images { get; set; }
        public CollectionItem CollectionItem { get; set; }


    }
}
