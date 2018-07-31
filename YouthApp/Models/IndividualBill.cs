using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YouthApp.Models
{
    public class IndividualBills
    {
        public long IndividualBillsID { get; set; }

        [Required]
        public Guid StudentsID { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public byte TermsID { get; set; }

        [DefaultValue(false)]
        public bool IsPaid { get; set; }

        public DateTime DateBilled { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }
             
        public virtual Students Students { get; set; }
    }
}
