using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YouthApp.Models
{
    public class IndividualBills
    {
        public long IndividualBillsID { get; set; }

        [Required]
        public long StudentsID { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Description { get; set; }

        [DefaultValue(false)]
        public bool IsPaid { get; set; }

        [StringLength(20,MinimumLength =5)]
        public string GCR { get; set; }

        public DateTime DateBilled { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual Students Students { get; set; }

    }
}
