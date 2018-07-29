using System;
using System.ComponentModel.DataAnnotations;

namespace YouthApp.Models
{
    public class ClassBills
    {
        public int ClassBillsID { get; set; }

        [Required]
        public int BillItemsID { get; set; }

        [Required]
        public int ClassesID { get; set; }

        [Required]
        [Range(0.1, double.MaxValue)]
        public double Amount { get; set; }

        [Required]
        public byte TermsID { get; set; }

        [Required]
        public string Year { get; set; }

        public DateTime DatePrepared { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual BillItems BillItems { get; set; }

        public virtual Classes Classes { get; set; }

        public virtual Terms Terms { get; set; }
    }
}
