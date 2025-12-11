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
    public class PassengerRepository : IPassengerRepository
    {

        private readonly AirportDbContext _db;

        public PassengerRepository(AirportDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Passenger passenger)
        {
            await _db.Passengers.AddAsync(passenger);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var passenger = await _db.Passengers.FindAsync(id);

            if (passenger != null)
            {
                _db.Passengers.Remove(passenger);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<Passenger>> GetAllAsync() =>

            await _db.Passengers.Include(p => p.Tickets)
                                .ToListAsync();

        public async Task<Passenger?> GetByIdAsync(Guid id) =>

            await _db.Passengers.Include(p => p.Tickets)
                                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task UpdateAsync(Passenger passenger)
        {
            _db.Passengers.Update(passenger);
            await _db.SaveChangesAsync();
        }
    }
}
