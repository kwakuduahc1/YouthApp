using System.ComponentModel.DataAnnotations;

namespace YouthApp.Models
{
    public class BillsVm
    {
        [Required]
        public int BillItemsID { get; set; }

        [Required]
        [Range(0.1, double.MaxValue)]
        public double Amount { get; set; }

        [Required]
        public short YearGroup { get; set; }

        [Required]
        public byte TermsID { get; set; }

    }
}
