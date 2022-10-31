using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEmployeeCollection.Models
{
    public class Student
    {
        [Key]
        [Required]
        public int BYUID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte International { get; set; }

        public string Gender { get; set; }

        public string EmailAddress { get; set; }

        public string Semester { get; set; }

        public int Year { get; set; }

        public string Phone { get; set; }

        public string ProgramYear { get; set; }

        public byte PayGradTuition { get; set; }

        public byte SubmittedEForm { get; set; }

        public DateTime SubmissionDate { get; set; }

        public string BYUName { get; set; }

        public string Notes { get; set; }

        //Foreign Key
        public int QualtricsSentID { get; set; }

        [ForeignKey("QualtricsSentID")]

        public QualtricsSent QualtricsSent { get; set; }

        [ForeignKey("BYUID")]

        public StudentPositionType StudentPositionType { get; set; }

        [ForeignKey("BYUID")]

        public Student_Supervisor Student_Supervisor { get; set; }

        public PositionType PositionType { get; set; }
        public Supervisor Supervisor { get; set; }

    }
}
