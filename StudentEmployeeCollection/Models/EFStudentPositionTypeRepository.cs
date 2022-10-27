using System;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public class EFStudentPositionTypeRepository : IStudentPositionTypeRepository
    {
        private StudentEmployeeDbContext _context { get; set; }

        public EFStudentPositionTypeRepository(StudentEmployeeDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<StudentPositionType> StudentPositionType => _context.StudentPositionType;
    }
}
