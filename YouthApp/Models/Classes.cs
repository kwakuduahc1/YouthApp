namespace YouthApp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Classes
    {
        public int ClassesID { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Required(AllowEmptyStrings = false)]
        public string ClassName { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<Students> Students { get; set; }

        public virtual ICollection<ClassBills> ClassBills { get; set; }
    }
}