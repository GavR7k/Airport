using Airport.Domain.Entities;
using Airport.Domain.Interfaces;
using Airport.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Airport.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AirportDbContext _db;

        public FlightRepository(AirportDbContext context)
        {
            _db = context;
        }

        public async Task<List<Flight>> GetAllAsync() =>
            await _db.Flights.Include(f => f.Gate)
                                  .Include(f => f.Tickets)
                                  .ToListAsync();

        public async Task<Flight?> GetByIdAsync(Guid id) =>
            await _db.Flights.Include(f => f.Gate)
                                  .Include(f => f.Tickets)
                                  .FirstOrDefaultAsync(f => f.Id == id);

        public async Task AddAsync(Flight flight)
        {
            await _db.Flights.AddAsync(flight);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Flight flight)
        {
            _db.Flights.Update(flight);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var flight = await _db.Flights.FindAsync(id);
            if (flight != null)
            {
                _db.Flights.Remove(flight);
                await _db.SaveChangesAsync();
            }
        }
    }
}
