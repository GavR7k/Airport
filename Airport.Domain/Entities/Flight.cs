using Airport.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain.Entities
{

    // Рейс
    public class Flight
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string ArrivalAirport { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public FlightStatus FlightStatus { get; set; }
        public Guid GateId { get; set; }
        public Gate? Gate { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    }
}
