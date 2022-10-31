using System;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public class EFPayIncreaseRepository : IPayIncreaseRepository
    {
        private StudentEmployeeDbContext _context { get; set; }

        public EFPayIncreaseRepository(StudentEmployeeDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<PayIncrease> PayIncrease => _context.PayIncrease;
    }
}
