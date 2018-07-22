using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PTE_Test_Helper.Models
{
    public class RO
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "文章标题不能超过50个英文字")]
        public string Title { get; set; }

        [Display(Name = "是否原文")]
        [Required]
        public bool IsComplete { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UpdateDate { get; set; }

    }
}
