using System;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public interface IPayIncreaseRepository
    {
        IQueryable<PayIncrease> PayIncrease { get; }
    }
}
