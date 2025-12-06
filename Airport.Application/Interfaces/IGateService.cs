using Airport.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Application.Interfaces
{
    public interface IGateService
    {
        //метод для возврата списка выходов 
        Task<List<GateDto>> GetGatesAsync();

        Task<GateDto> CreateGateAsync(GateDto dto);

        Task<GateDto?> GetGateAsync(Guid id);

        //метод для удаления полета
        Task<bool> DeleteGateAsync(Guid id);

        //метод для изменения полета
        Task<bool> UpdateGateAsync(GateDto dto);

    }
}
