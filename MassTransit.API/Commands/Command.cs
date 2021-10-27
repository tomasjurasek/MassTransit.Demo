using System;

namespace MassTransit.API.Commands
{
    public class Command
    {
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CommandJson { get; set; }
    }
}
