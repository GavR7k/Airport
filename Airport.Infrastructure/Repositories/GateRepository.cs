using Airport.Domain.Entities;
using Airport.Domain.Interfaces;
using Airport.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Infrastructure.Repositories
{
    public class GateRepository : IGateRepository
    {

        private readonly AirportDbContext _db;
        public GateRepository(AirportDbContext airportDbContext)
        {
            _db = airportDbContext;
        }

        public async Task AddAsync(Gate gate)
        {
            await _db.Gates.AddAsync(gate);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var gate = await _db.Gates.FindAsync(id);

            if (gate != null)
            {

                _db.Gates.Remove(gate);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<Gate>> GetAllAsync()
        {
            return await _db.Gates
                .Include(g => g.Flights)
                .ToListAsync();
        }

        public async Task<Gate?> GetByIdAsync(Guid id)
        {
            return await _db.Gates
                .Include(g => g.Flights)
                .Where(g => g.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Gate gate)
        {
            _db.Gates.Update(gate);
            await _db.SaveChangesAsync();

        }
    }
}
