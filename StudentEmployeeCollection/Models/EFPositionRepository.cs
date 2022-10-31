using System;
using System.Linq;

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
    }
}
