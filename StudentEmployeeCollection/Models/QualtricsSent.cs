using System;
using System.ComponentModel.DataAnnotations;

namespace StudentEmployeeCollection.Models
{
    public class QualtricsSent
    {
        [Key]
        [Required]
        public int QualtricsSentID { get; set; }

        public string QualtricsURL { get; set; }
    }
}
