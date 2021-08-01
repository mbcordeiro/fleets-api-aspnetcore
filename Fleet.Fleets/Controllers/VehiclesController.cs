using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fleet.Fleets.Domain.Interface;
using Fleet.Fleets.Domain.Domain;

namespace Fleet.Fleets.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IVehicleDetran vehicleDetran;

        public VehiclesController(IVehicleRepository vehicleRepository, IVehicleDetran vehicleDetran)
        {
            this.vehicleRepository = vehicleRepository;
            this.vehicleDetran = vehicleDetran;
        }

        [HttpGet]
        public IActionResult Get() => Ok(vehicleRepository.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var veiculo = vehicleRepository.GetById(id);
            if (veiculo == null)
                return NotFound();
            return Ok(veiculo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Vehicle vehicle)
        {
            vehicleRepository.Add(vehicle);
            return CreatedAtAction(nameof(Get), new { id = vehicle.Id }, vehicle);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Vehicle vehicle)
        {
            vehicleRepository.Update(vehicle);

            return NoContent();
        }

        [HttpPut("{id}/inspection-detran")]
        public IActionResult Put(Guid id)
        {
            vehicleDetran.ScheduleDetranInspection(id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var vehicle = vehicleRepository.GetById(id);
            if (vehicle == null)
                return NotFound();

            vehicleRepository.Delete(vehicle);

            return NoContent();
        }
    }
}
