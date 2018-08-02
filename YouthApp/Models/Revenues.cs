using System.ComponentModel.DataAnnotations;

namespace YouthApp.Models
{
    public class Revenues
    {
        [Key]
        public short RevenuesID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string AccountName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string AccountNumber { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string Source { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Bank { get; set; }
    }
}
