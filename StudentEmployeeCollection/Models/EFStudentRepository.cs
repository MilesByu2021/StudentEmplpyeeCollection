using System;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public class EFStudentRepository : IStudentRepository
    {
        private StudentEmployeeDbContext _context { get; set; }

        public EFStudentRepository(StudentEmployeeDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Student> Student => _context.Student;

        public void CreateStudent(Student s)
        {
            _context.Add(s);
            _context.SaveChanges();
        }

        public void SaveStudent(Student s)
        {
            _context.Update(s);
            _context.SaveChanges();
        }
        public void DeleteStudent(Student s)
        {
            _context.Remove(s);
            _context.SaveChanges();
        }

    }
}
