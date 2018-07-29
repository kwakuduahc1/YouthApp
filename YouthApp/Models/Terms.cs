using System.ComponentModel.DataAnnotations;

namespace YouthApp.Models
{
    public class Terms
    {
        [Key]
        public byte TermsID { get; set; }

        [Required]
        [Range(1.1, 3.3)]
        public float Term { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
