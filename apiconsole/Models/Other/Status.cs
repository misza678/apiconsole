using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiconsole.Models.Other
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public string Name { get; set; }
    }
}
