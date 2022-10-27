using System;
using System.ComponentModel.DataAnnotations;

namespace StudentEmployeeCollection.Models
{
    public class Supervisor
    {
        [Key]
        [Required]
        public int SupervisorID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


    }
}
