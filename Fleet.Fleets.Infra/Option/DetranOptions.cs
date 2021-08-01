using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet.Fleets.Infra.Model
{
    public class DetranOptions
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string BaseUrl { get; set; }
        public string InspectionUri { get; set; }
        public int NumberOfDaysToSchedule { get; set; }
    }
}
