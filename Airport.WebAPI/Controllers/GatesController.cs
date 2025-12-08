using Airport.Application.DTOs;
using Airport.Application.Interfaces;
using Airport.Application.Services;
using Airport.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Airport.WebAPI.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class GatesController : ControllerBase
    {
        private readonly IGateService _gateService;
        public GatesController(IGateService gateService)
        {
            _gateService = gateService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GateDto>>> GetAll()
        {
            var gates = await _gateService.GetGatesAsync();
            return Ok(gates);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GateDto>> GetById(Guid id)
        {
            var gate = await _gateService.GetGateAsync(id);

            if (gate == null)
                return NotFound();

            return Ok(gate);
        }

        
        [HttpPost]
        public async Task<ActionResult<GateDto>> Create([FromBody] GateDto dto)
        {
            var created = await _gateService.CreateGateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] GateDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch");

            var success = await _gateService.UpdateGateAsync(dto);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _gateService.DeleteGateAsync(id);
            if (!success) return NotFound();
            return NoContent();

        }
    }
}
