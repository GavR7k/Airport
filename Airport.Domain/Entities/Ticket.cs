using Airport.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain.Entities
{

    //Билет
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;

        public ClassStatus Status { get; set; }

        public decimal Price { get; set; }

        public Guid FlightId { get; set; }
        public Flight Flight { get; set; }

        public Guid PassengerId { get; set; }
        public Passenger Passenger { get; set; }

    }
}
