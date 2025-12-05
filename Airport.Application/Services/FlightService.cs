using Airport.Application.DTOs;
using Airport.Application.Interfaces;
using Airport.Domain.Entities;
using Airport.Domain.Enums;
using Airport.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Application.Services
{
    public class FlightService : IFlightService
    {

        private readonly IFlightRepository _flightRepository;
        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<FlightDto> CreateFlightAsync(FlightDto dto)
        {
            var flight = MapToEntity(dto);
            await _flightRepository.AddAsync(flight);
            return MapToDto(flight);
        }

        public async Task<bool> DeleteFlightAsync(Guid id)
        {
            var flight = await _flightRepository.GetByIdAsync(id);
            if (flight == null) return false;

            await _flightRepository.DeleteAsync(id);
            return true;
        }

        public async Task<FlightDto?> GetFlightAsync(Guid id)
        {
            var flight = await _flightRepository.GetByIdAsync(id);
            return flight == null ? null : MapToDto(flight);
        }

        public async Task<List<FlightDto>> GetFlightsAsync()
        {
            var flights = await _flightRepository.GetAllAsync();
            return flights.Select(MapToDto).ToList();
        }

        public async Task<bool> UpdateFlightAsync(FlightDto dto)
        {
            var flight = await _flightRepository.GetByIdAsync(dto.Id);
            if (flight == null) return false;

            flight.Number = dto.Number;
            flight.CompanyName = dto.CompanyName;
            flight.ArrivalAirport = dto.ArrivalAirport;
            flight.DepartureTime = dto.DepartureTime;
            flight.ArrivalTime = dto.ArrivalTime;
            flight.FlightStatus = dto.FlightStatus;
            flight.GateId = dto.GateId;

            await _flightRepository.UpdateAsync(flight);
            return true;
        }

        private static FlightDto MapToDto(Flight flight)
        {
            return new FlightDto
            {
                Id = flight.Id,
                Number = flight.Number,
                CompanyName = flight.CompanyName,
                ArrivalAirport = flight.ArrivalAirport,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                FlightStatus = flight.FlightStatus,
                GateId = flight.GateId
            };
        }

        private static Flight MapToEntity(FlightDto dto)
        {
            return new Flight
            {
                Id = dto.Id == Guid.Empty ? Guid.NewGuid() : dto.Id,
                Number = dto.Number,
                CompanyName = dto.CompanyName,
                ArrivalAirport = dto.ArrivalAirport,
                DepartureTime = dto.DepartureTime,
                ArrivalTime = dto.ArrivalTime,
                FlightStatus = dto.FlightStatus,
                GateId = dto.GateId
            };
        }

     
    }
}
