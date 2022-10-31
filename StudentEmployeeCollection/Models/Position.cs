using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEmployeeCollection.Models
{
    public class Position
    {
        public Position()
        {

        }
        [Key]
        [Required]
        public int PositionID { get; set; }
        public int EmplRec { get; set; }
        public DateTime? HireDate { get; set; }
        public int ExpectedHours { get; set; }
        public DateTime? TerminationDate { get; set; }
        public bool AuthToWorkReceive { get; set; }
        public DateTime? AuthToWorkMailSentDate { get; set; }
        public string ClassCode { get; set; }
        public string QualtricsURL { get; set; }
        public decimal PayRate { get; set; }
        
        public int PositionTypeID { get; set; }
        public int SupervisorID { get; set; }
        public string BYUID { get; set; }

        [ForeignKey("PositionTypeID")]
        public PositionType PositionType { get; set; }
        
        [ForeignKey("BYUID")]
        public Student Student { get; set; }

        [ForeignKey("SupervisorID")]
        public Supervisor Supervisor { get; set; }
    }
}
