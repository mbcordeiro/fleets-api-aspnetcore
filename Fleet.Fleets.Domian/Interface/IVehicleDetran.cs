using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet.Fleets.Domain.Interface
{
    public interface IVehicleDetran
    {
        public Task ScheduleDetranInspection(Guid vehicleId);
    }
}
