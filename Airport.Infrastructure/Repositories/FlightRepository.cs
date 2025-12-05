using Airport.Domain.Entities;
using Airport.Domain.Interfaces;
using Airport.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Airport.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AirportDbContext _context;

        public FlightRepository(AirportDbContext context)
        {
            _context = context;
        }

        public async Task<List<Flight>> GetAllAsync() =>
            await _context.Flights.Include(f => f.Gate)
                                  .Include(f => f.Tickets)
                                  .ToListAsync();

        public async Task<Flight?> GetByIdAsync(Guid id) =>
            await _context.Flights.Include(f => f.Gate)
                                  .Include(f => f.Tickets)
                                  .FirstOrDefaultAsync(f => f.Id == id);

        public async Task AddAsync(Flight flight)
        {
            await _context.Flights.AddAsync(flight);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Flight flight)
        {
            _context.Flights.Update(flight);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                await _context.SaveChangesAsync();
            }
        }
    }
}
