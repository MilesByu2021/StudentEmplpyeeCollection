using System;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public interface ISupervisorRepository
    {
        IQueryable<Supervisor> Supervisor { get; }
    }
}
