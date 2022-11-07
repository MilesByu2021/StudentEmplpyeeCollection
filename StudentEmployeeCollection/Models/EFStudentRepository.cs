using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public IQueryable<Student> GetStudentsQuery()
        {
            return _context.Student
                .Include(s => s.Positions)
                    .ThenInclude(p => p.Supervisor)
                .Include(s => s.Positions)
                    .ThenInclude(p => p.PositionType);
        }

        public List<string> GetSemesters()
        {
            return _context.Student.Select(s => s.Semester).Distinct().ToList();
        }

        public List<int> GetYears()
        {
            return _context.Student.Select(s => s.Year).Distinct().ToList();
        }
    }
}
