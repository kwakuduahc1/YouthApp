using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YouthApp.Models
{
    public class TransactionsTypes
    {
        [Key]
        [Required]
        public byte TransactionsTypesID { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string TransactionType { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public ICollection<Transactions> Transactions { get; set; }
    }

    public enum TranTypes : byte
    {
        Revenue = 1, Expenditure = 2,
    }
}