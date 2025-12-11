using Airport.Application.DTOs;
using Airport.Application.Interfaces;
using Airport.Domain.Entities;
using Airport.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Application.Services
{
    public class PassengerService : IPassengerService
    {

        private readonly IPassengerRepository _repository;

        public PassengerService(IPassengerRepository repository)
        {
            _repository = repository;
        }


        public async Task<PassengerDto> CreatePassengerAsync(PassengerDto dto)
        {
            var passenger = MapToEntity(dto);
            await _repository.AddAsync(passenger);
            return MapToDto(passenger);
        }



        public async Task<bool> DeletePassengerAsync(Guid id)
        {
            var passenger = await _repository.GetByIdAsync(id);
            if (passenger != null)
            {
                await _repository.DeleteAsync(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<PassengerDto?> GetPassengerAsync(Guid id)
        {
            var passenger = await _repository.GetByIdAsync(id);
            return passenger != null ? MapToDto(passenger) : null;
        }

        public async Task<List<PassengerDto>> GetPassengersAsync()
        {
            var passengers = await _repository.GetAllAsync();
            return passengers.Select(MapToDto).ToList();
        }

        public async Task<bool> UpdatePassengerAsync(PassengerDto dto)
        {
            var passenger = await _repository.GetByIdAsync(dto.Id);
            if (passenger == null) return false;

            passenger.Name = dto.Name;
            passenger.PassportNumber = dto.PassportNumber;

            await _repository.UpdateAsync(passenger);
            return true;
        }
        private static PassengerDto MapToDto(Passenger passenger)
        {
            return new PassengerDto
            {
                Id = passenger.Id,
                Name = passenger.Name,
                PassportNumber = passenger.PassportNumber
            };
        }

        private static Passenger MapToEntity(PassengerDto dto)
        {
            return new Passenger
            {
                Id = dto.Id == Guid.Empty ? Guid.NewGuid() : dto.Id,
                Name = dto.Name,
                PassportNumber = dto.PassportNumber
            };
        }
    }
}
