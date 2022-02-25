using Microsoft.EntityFrameworkCore;

namespace apiconsole.Models.Repair
{
   
    public class DefectModel
    {

        public int DefectID { get; set; }
        public Defect Defect { get; set; }  
        public int ModelID { get; set; }
        public Model Model { get; set; }
    }
}
