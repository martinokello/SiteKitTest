using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Bmi
    {
        [Key]
        public int BmiId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        public int PatientId { get; set; }
        public double PatientBmi { get; set; }

    }
}
