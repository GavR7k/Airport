using Airport.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain.Entities
{


    //Выход на посадку
    public class Gate
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Terminal { get; set; } = string.Empty;

        public GateStatus Status { get; set; }
        public List<Flight> FlightsList { get; set; } = new List<Flight>();

    }
}
