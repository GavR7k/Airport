using Airport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain.Interfaces
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetAllAsync();
        Task<Flight?> GetByIdAsync(Guid id);
        Task AddAsync(Flight flight);
        Task UpdateAsync(Flight flight);
        Task DeleteAsync(Guid id);
    }
}
