using System;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public class EFStudent_SupervisorRepository : IStudent_SupervisorRepository
    {
        private StudentEmployeeDbContext _context { get; set; }

        public EFStudent_SupervisorRepository(StudentEmployeeDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Student_Supervisor> Student_Supervisor => _context.Student_Supervisor;
    }
}
