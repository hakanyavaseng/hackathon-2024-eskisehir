using HackAPI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackAPI.Entities.DTOs.Transportations
{
    public class AddTransportationDto
    {
        public DateTime TransportationDateTime { get; init; }
        public decimal Distance { get; init; }
        public Guid VehicleId { get; init; }
        public decimal TotalCarbonFootprint { get; init; }


    }
}
