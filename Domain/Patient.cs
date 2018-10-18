using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public BmiCategory BmiCategory { get; set; }
        public int BmiCategoryId { get; set; }

        public float Weight { get; set; }
        public float Height { get; set; }
    }
}
