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



        public Task<bool> DeletePassengerAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PassengerDto?> GetPassengerAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PassengerDto>> GetPassengersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePassengerAsync(PassengerDto dto)
        {
            throw new NotImplementedException();
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
