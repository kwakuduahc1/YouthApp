using System.ComponentModel.DataAnnotations;

namespace YouthApp.Models
{
    public class ReceiveModel
    {
        [Required]
        public long IndividualBillsID { get; set; }

        [Required]
        public long StudentsID { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Required]
        public string GCR { get; set; }

    }
}
