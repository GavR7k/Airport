using Airport.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Application.Interfaces
{
    public interface IFlightService
    {
        //метод для возврата списка всех полетов
        Task<List<FlightDto>> GetFlightsAsync();

        //метод для добавления полета
        Task<FlightDto> CreateFlightAsync(FlightDto dto);

        //метод для возврата одного конкретного полета
        Task<FlightDto?> GetFlightAsync(Guid id);

        //метод для удаления полета
        Task<bool> DeleteFlightAsync(Guid id);

        //метод для изменения полета
        Task<bool> UpdateFlightAsync(FlightDto dto);
    }
}
