using System;
using System.ComponentModel.DataAnnotations;

namespace YouthApp.Models
{
    public class Transactions
    {
        [Key]
        public long TransactionsID { get; set; }

        [Required]
        public double Amount { get; set; }

        public bool IsStudent { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Purpose { get; set; }

        [Required]
        public short RevenuesID { get; set; }

        [Required]
        public byte TransactionsTypesID { get; set; }

        [Required]
        public short TransactionItemsID { get; set; }

        public DateTime TransactionDate { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual Revenues Revenues { get; set; }

        public virtual TransactionsTypes TransactionsTypes { get; set; }

        public virtual TransactionItems TransactionItems { get; set; }
    }
}