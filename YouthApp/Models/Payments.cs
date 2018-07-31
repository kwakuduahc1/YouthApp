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

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual Students Students { get; set; }
    }
}
