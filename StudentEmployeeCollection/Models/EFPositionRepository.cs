using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StudentEmployeeCollection.Models
{
    public class EFPositionRepository : IPositionRepository
    {
        private StudentEmployeeDbContext _context { get; set; }

        public EFPositionRepository(StudentEmployeeDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Position> Position => _context.Position;

        public void CreatePosition(Position position)
        {
            _context.Add(position);
            _context.SaveChanges();
        }

        public void SavePosition(Position position)
        {
            _context.Update(position);
            _context.SaveChanges();
        }
        public void DeletePosition(Position position)
        {
            _context.Remove(position);
            _context.SaveChanges();
        }

        public IQueryable<Position> GetPositionsQuery()
        {
            return _context.Position
                .Include(p => p.Student)
                .Include(p => p.Supervisor)
                .Include(p => p.PositionType);
        }
    }
}
