﻿using System;
using System.ComponentModel.DataAnnotations;

namespace YouthApp.Models
{
    public class Transactions
    {
        [Key]
        public long TransactionsID { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public short RevenuesID { get; set; }

        [Required]
        public short TransactionsTypesID { get; set; }

        public DateTime TransactionDate { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual Revenues Revenues { get; set; }

        public virtual TransactionsTypes TransactionsTypes { get; set; }
    }
}