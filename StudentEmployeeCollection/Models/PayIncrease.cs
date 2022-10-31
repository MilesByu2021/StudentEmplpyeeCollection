using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace StudentEmployeeCollection.Models
{
    public class PayIncrease
    {
        public PayIncrease()
        {

        }
        [Key]
        [Required]
        public int PayIncreaseID { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int PositionID { get; set; }

        [ForeignKey("PositionID")]
        public Position Position { get; set; }
    }
}
