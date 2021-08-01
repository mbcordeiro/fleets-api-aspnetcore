using Fleet.Fleets.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet.Fleets.Infra.EntityFramework
{
    public class FleetContext : DbContext
    {
        public FleetContext(DbContextOptions<FleetContext> options) 
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
