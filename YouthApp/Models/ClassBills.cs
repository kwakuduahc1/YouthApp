using System;
using System.ComponentModel;
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
        [DefaultValue(1)]
        public byte TermsID { get; set; }

        [Required]
        [Range(0.1, double.MaxValue)]
        public double Amount { get; set; }

        [Required]
        [Range(2016, 2050)]
        public short YearGroup { get; set; }

        public DateTime DatePrepared { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual BillItems BillItems { get; set; }

        public virtual Classes Classes { get; set; }

        public virtual Terms Terms { get; set; }
    }
}
