using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class BmiCategory
    {
        [Key]
        public int BmiCategoryId { get; set; }
        public string Category { get; set; }
        public string BmiRange { get; set; }
    }
}
