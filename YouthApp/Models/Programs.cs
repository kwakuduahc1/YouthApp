using System.Collections.Generic;

namespace YouthApp.Models
{
    public class Programs
    {
        public short ProgramsID { get; set; }

        public string ProgramName { get; set; }

        public virtual ICollection<Classes> Classes { get; set; }
    }
}
