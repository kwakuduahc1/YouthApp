using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YouthApp.Models
{
    public class TransactionItems
    {
        [Key]
        public short TransactionItemsID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string TransactionItem { get; set; }

        public ICollection<Transactions> Transactions { get; set; }
    }
}
