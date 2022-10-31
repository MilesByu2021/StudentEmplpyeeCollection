using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEmployeeCollection.Models
{
    public class Student
    {
        public Student()
        {

        }
        [Key]
        [Required]
        public string BYUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool International { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }
        public string Phone { get; set; }
        public string ProgramYear { get; set; }
        public bool PayGradTuition { get; set; }
        public bool SubmittedEForm { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string BYUName { get; set; }
        public string Notes { get; set; }
        public bool NameChangeCompleted { get; set; }
        public List<Position> Positions { get; set; }
    }
}
