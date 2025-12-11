using Airport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain.Interfaces
{
    public interface IPassengerRepository
    {
        Task<List<Passenger>> GetAllAsync();
        Task<Passenger?> GetByIdAsync(Guid id);
        Task AddAsync(Passenger passenger);
        Task UpdateAsync(Passenger passenger);
        Task DeleteAsync(Guid id);
    }
}
