using System;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public class EFSupervisorRepository : ISupervisorRepository
    {
        private StudentEmployeeDbContext _context { get; set; }

        public EFSupervisorRepository(StudentEmployeeDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Supervisor> Supervisor => _context.Supervisor;
    }
}
