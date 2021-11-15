using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vezeeta.Models
{
    public class InsuranceDoctor
    {
        [Key]
        [Column(Order = 1)]
        public int DoctorID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int InsuranceID { get; set; }
    }
}