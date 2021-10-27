using MassTransit.API.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MassTransit.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IBus _bus;

        public DataController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommand command)
        {
            await _bus.Publish(new Command
            {
                CommandJson = JsonSerializer.Serialize(command),
                Type = command.GetType().Name,
                CreatedAt = DateTime.UtcNow
            });
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCommand command)
        {
            await _bus.Publish(new Command
            {
                CommandJson = JsonSerializer.Serialize(command),
                Type = command.GetType().Name,
                CreatedAt = DateTime.UtcNow
            });
            return Ok();
        }
    }
}
