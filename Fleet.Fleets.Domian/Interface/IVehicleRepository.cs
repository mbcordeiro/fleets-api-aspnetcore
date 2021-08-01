using Fleet.Fleets.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet.Fleets.Domain.Interface
{
    public interface IVehicleRepository
    {
        void Add(Vehicle vehicle);
        void Delete(Vehicle vehicle);
        void Update(Vehicle vehicle);
        Vehicle GetById(Guid Id);
        IEnumerable<Vehicle> GetAll();
    }
}
