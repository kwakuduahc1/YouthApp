namespace YouthApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class StudentsInfo
    {
        [ForeignKey("Students")]
        [Key]
        public Guid StudentsID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string Mother { get; set; }

        [StringLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string Father { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string PlaceOfBirth { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual Students Students { get; set; }
    }
}