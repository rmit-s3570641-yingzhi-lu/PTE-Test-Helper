using System;
using System.ComponentModel.DataAnnotations;

namespace PTE_Test_Helper.Models
{
    public class Paragraph
    {
        [Required]
        public int ID { get; set; }
        public int ParentId { get; set; }
        public string Content { get; set; }
        [Required]
        [Range(1, 10)]
        public int Location { get; set; }

    }
}
