using System;
using System.ComponentModel.DataAnnotations;

namespace StudentEmployeeCollection.Models
{
    public class PositionType
    {
        [Key]
        [Required]
        public int PositionTypeID { get; set; }

        public string PositionTypes { get; set; }

        public Decimal PayRate { get; set; }

        public byte NameChangeComp { get; set; }
    }
}
