using Microsoft.AspNetCore.Mvc;
using Airport.Application.Interfaces;
using System.Threading.Tasks;
using Airport.Application.DTOs;

namespace Airport.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }


        [HttpGet]
        public async Task<ActionResult<List<FlightDto>>> GetAll()
        {
            var flights = await _flightService.GetFlightsAsync();
            return Ok(flights);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightDto>> GetById(Guid id)
        {
            var flight = await _flightService.GetFlightAsync(id);

            if (flight == null) return NotFound();

            return Ok(flight);
        }

        [HttpPost]
        public async Task<ActionResult<FlightDto>> Create([FromBody] FlightDto dto)
        {
            var created = await _flightService.CreateFlightAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/flights/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] FlightDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch");

            var success = await _flightService.UpdateFlightAsync(dto);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _flightService.DeleteFlightAsync(id);
            if (!success) return NotFound();
            return NoContent();

        }

    }
}
