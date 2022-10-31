using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEmployeeCollection.Models
{
    public class StudentPositionType
    {
        [Key]
        [Required]
        public int BYUID { get; set; }

        public int EmplRec { get; set; }

        public DateTime HireDate { get; set; }

        public int ExpectedHours { get; set; }

        public DateTime LastPayIncrease { get; set; }

        public Decimal PayIncreaseAmt { get; set; }

        public DateTime IncreaseDate { get; set; }

        public byte Terminated { get; set; }

        public DateTime TerminationDate { get; set; }

        public byte AuthToWorkReceive { get; set; }

        public DateTime AuthToWorkMailSentDate { get; set; }

        public string ClassCode { get; set; }

        //Foreign Key
        public int PositionTypeID { get; set; }

        [ForeignKey("PositionTypeID")]

        public PositionType PositionType { get; set; }
    }
}
