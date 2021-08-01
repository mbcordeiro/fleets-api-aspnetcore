using Fleet.Fleets.Domain.Interface;
using Fleet.Fleets.Infra.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fleet.Fleets.Infra.Facade
{
    public class VehicleDetranFacade : IVehicleDetran
    {
        private readonly DetranOptions detranOptions;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IVehicleRepository vehicleRepository;

        public VehicleDetranFacade(IOptionsMonitor<DetranOptions> optionsMonitor, IHttpClientFactory httpClientFactory, IVehicleRepository IVehicleRepository)
        {
            this.detranOptions = optionsMonitor.CurrentValue;
            this.httpClientFactory = httpClientFactory;
            this.vehicleRepository = vehicleRepository;
        }
        public async Task ScheduleDetranInspection(Guid vehicleId)
        {
            var vehicle = vehicleRepository.GetById(vehicleId);

            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(detranOptions.BaseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var requestModel = new InspectionModel()
            {
                LicensePlate = vehicle.LicensePlate,
                ScheduledTo = DateTime.Now.AddDays(detranOptions.NumberOfDaysToSchedule)
            };
            var jsonContent = JsonSerializer.Serialize(requestModel);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            await client.PostAsync(detranOptions.InspectionUri, contentString);
        }
    }
}
