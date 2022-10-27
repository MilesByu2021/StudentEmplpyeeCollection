using System;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public interface IStudent_SupervisorRepository
    {
        IQueryable<Student_Supervisor> Student_Supervisor { get; }
    }
}
