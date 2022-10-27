using System;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public interface IPositionTypeRepository
    {
        IQueryable<PositionType> PositionType { get; }
    }
}
