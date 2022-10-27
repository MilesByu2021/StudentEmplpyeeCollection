using System;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public interface IStudentRepository
    {
        IQueryable<Student> Student { get; }

        public void CreateStudent(Student s);

        public void SaveStudent(Student s);

        public void DeleteStudent(Student s);
    }
}
