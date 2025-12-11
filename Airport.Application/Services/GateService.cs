using Airport.Application.DTOs;
using Airport.Application.Interfaces;
using Airport.Domain.Entities;
using Airport.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Airport.Application.Services
{
    public class GateService : IGateService
    {
        private readonly IGateRepository _repository;

        public GateService(IGateRepository gateRepository)
        {
            _repository = gateRepository;
        }
        public async Task<GateDto> CreateGateAsync(GateDto dto)
        {
            var gate = MapToEntity(dto);
            await _repository.AddAsync(gate);
            return MapToDto(gate);
        }

        public async Task<bool> DeleteGateAsync(Guid id)
        {
            var gate = await _repository.GetByIdAsync(id);
            if (gate == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<GateDto?> GetGateAsync(Guid id)
        {
            var gate = await _repository.GetByIdAsync(id);
            return gate == null ? null : MapToDto(gate);
        }

        public async Task<List<GateDto>> GetGatesAsync()
        {
            var listofgates = await _repository.GetAllAsync();
            return listofgates.Select(MapToDto).ToList();
        }

        public async Task<bool> UpdateGateAsync(GateDto dto)
        {
            var gate = await _repository.GetByIdAsync(dto.Id);
            if (gate == null) return false;

            gate.Number = dto.Number;
            gate.Terminal = dto.Terminal;
            gate.Status = dto.Status;

            await _repository.UpdateAsync(gate);
            return true;
        }

        private static GateDto MapToDto(Gate gate)
        {
            return new GateDto
            {
                Id = gate.Id,
                Number = gate.Number,
                Terminal = gate.Terminal,
                Status = gate.Status,
            };
        }

        private static Gate MapToEntity(GateDto dto)
        {
            return new Gate
            {
                Id = dto.Id == Guid.Empty ? Guid.NewGuid() : dto.Id,
                Number = dto.Number,
                Terminal = dto.Terminal,
                Status = dto.Status

            };
        }
    }
}
