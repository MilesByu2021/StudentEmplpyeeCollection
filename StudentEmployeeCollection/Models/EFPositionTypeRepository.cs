using System;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public class EFPositionTypeRepository : IPositionTypeRepository
    {
        private StudentEmployeeDbContext _context { get; set; }

        public EFPositionTypeRepository(StudentEmployeeDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<PositionType> PositionType => _context.PositionType;
    }
}
