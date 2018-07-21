using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PTE_Test_Helper.Models
{
    public class RO
    {
        [Required]
        public int ID { get; set; }

        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Title { get; set; }

        [Display(Name = "If it is gist")]
        public bool IsComplete { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UpdateDate { get; set; }

    }
}
