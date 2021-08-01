using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet.Fleets.Domain.Domain
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string YearManufacture { get; set; }
    }
}
