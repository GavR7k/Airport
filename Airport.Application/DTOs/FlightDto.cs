using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.Domain.Enums;

namespace Airport.Application.DTOs
{
    public class FlightDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string ArrivalAirport { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public FlightStatus FlightStatus { get; set; }
        public Guid? GateId { get; set; }
    }
}
