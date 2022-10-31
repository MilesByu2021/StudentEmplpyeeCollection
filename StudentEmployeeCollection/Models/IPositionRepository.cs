using System;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public interface IPositionRepository
    {
        IQueryable<Position> Position { get; }
    }
}
