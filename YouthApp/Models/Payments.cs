using System;
using System.ComponentModel.DataAnnotations;

namespace YouthApp.Models
{
    public class Payments
    {
        public Guid PaymentsID { get; set; }

        [Required]
        public long StudentsID { get; set; }

        [Range(minimum: 0, maximum: double.MaxValue)]
        [Required]
        public double Amount { get; set; }

        public DateTime DatePaid { get; set; }

        [StringLength(50, MinimumLength = 10)]
        public string Receiver { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Required(AllowEmptyStrings = false)]
        public string GCR { get; set; }

        [Required]
        public long TransactionsID { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual Students Students { get; set; }

        public virtual Transactions Transactions { get; set; }
    }
}
