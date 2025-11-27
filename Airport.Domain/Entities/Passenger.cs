    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Airport.Domain.Entities
    {

        //Пассажир
        public class Passenger
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string PassportNumber { get; set; } = string.Empty;
            public List<Ticket> Ticket { get; set; } = new List<Ticket>();
        }
    }
