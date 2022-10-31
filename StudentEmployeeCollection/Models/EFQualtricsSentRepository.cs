using System;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public class EFQualtricsSentRepository : IQualtricsSentRepository
    {
        private StudentEmployeeDbContext _context { get; set; }

        public EFQualtricsSentRepository(StudentEmployeeDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<QualtricsSent> QualtricsSent => _context.QualtricsSent;
    }
}
