using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public interface IStudentRepository
    {
        IQueryable<Student> Student { get; }

        public void CreateStudent(Student s);

        public void SaveStudent(Student s);

        public void DeleteStudent(Student s);

        public IQueryable<Student> GetStudentsQuery();
        public List<string> GetSemesters();
        public List<int> GetYears();
    }
}
