using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YouthApp.Models
{
    public class BillItems
    {
        public int BillItemsID { get; set; }

        [Required]
        [StringLength(100)]
        public string BillItem { get; set; }

        [StringLength(100, MinimumLength =5)]
        public string Description { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<ClassBills> ClassBills { get; set; }
    }
}
