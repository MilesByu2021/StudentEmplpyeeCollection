using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEmployeeCollection.Models
{
    public class Student_Supervisor
    {
        [Key]
        [Required]
        public int BYUID { get; set; }

        //Foreign Key
        public int SupervisorID { get; set; }

        [ForeignKey("SupervisorID")]

        public Supervisor Supervisor { get; set; }

    }
}
