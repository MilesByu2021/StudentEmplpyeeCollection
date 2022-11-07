using System;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public interface IPositionRepository
    {
        IQueryable<Position> Position { get; }
        public void CreatePosition(Position position);
        public void SavePosition(Position position);
        public void DeletePosition(Position position);
        public IQueryable<Position> GetPositionsQuery();
    }
}
