using Airport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Application.DTOs
{
    public class PassengerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PassportNumber { get; set; } = string.Empty;
    }
}
