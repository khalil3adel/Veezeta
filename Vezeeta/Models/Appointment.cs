using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vezeeta.Models
{
    public class Appointment
    {
        [Key]
        [Column(Order = 1)]
        public int DoctorID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int PatientID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        //property sataus => pending , approve , regect > Enum
        //
    }
}