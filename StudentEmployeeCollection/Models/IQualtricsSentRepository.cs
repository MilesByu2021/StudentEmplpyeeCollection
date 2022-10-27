using System;
using System.Linq;

namespace StudentEmployeeCollection.Models
{
    public interface IQualtricsSentRepository
    {
        IQueryable<QualtricsSent> QualtricsSent { get; }
    }
}
