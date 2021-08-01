using Fleet.Fleets.Infra.Singleton;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fleet.Fleets.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SingletonController : ControllerBase
    {
        public SingletonController(SingletonContainer singletonContainer)
        {
            SingletonContainer = singletonContainer;
        }

        public SingletonContainer SingletonContainer { get; }

        [HttpGet]
        public IActionResult GetSingleton()
        {
            return Ok(SingletonContainer);
        }
    }
}
