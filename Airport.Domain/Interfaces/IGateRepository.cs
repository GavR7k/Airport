using Airport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain.Interfaces
{
    public interface IGateRepository
    {
        Task<List<Gate>> GetAllAsync();
        Task<Gate?> GetByIdAsync(Guid id);
        Task AddAsync(Gate gate);
        Task UpdateAsync(Gate gate);
        Task DeleteAsync(Guid id);
    }
}
