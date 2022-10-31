using System;
using System.ComponentModel.DataAnnotations;

namespace StudentEmployeeCollection.Models
{
    public class PositionType
    {
        public PositionType()
        {

        }
        [Key]
        [Required]
        public int PositionTypeID { get; set; }
        public string PositionName { get; set; }
    }
}
