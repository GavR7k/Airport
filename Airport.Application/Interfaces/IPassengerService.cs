using Airport.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Application.Interfaces
{
    public interface IPassengerService
    {
        Task<List<PassengerDto>> GetPassengersAsync();

        Task<PassengerDto> CreatePassengerAsync(PassengerDto dto);

        Task<PassengerDto?> GetPassengerAsync(Guid id);

        Task<bool> DeletePassengerAsync(Guid id);

        Task<bool> UpdatePassengerAsync(PassengerDto dto);
    }
}
