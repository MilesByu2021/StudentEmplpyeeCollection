using System;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public interface IStudentPositionTypeRepository
    {
        IQueryable<StudentPositionType> StudentPositionType { get; }
    }
}
