using MassTransit.API.Commands;
using MassTransit.Mediator;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MassTransit.API.CommandConsumers
{
    public class CommandConsumer : IConsumer<Command>
    {
        private readonly IMediator _mediator;

        public CommandConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<Command> context)
        {
            var type = GetType(context.Message.Type);
            var command = JsonConvert.DeserializeObject(context.Message.CommandJson, type);
            await _mediator.Send(command);
        }


        private Type GetType(string type)
        {
            return type switch
            {
                nameof(CreateCommand) => typeof(CreateCommand),
                nameof(UpdateCommand) => typeof(UpdateCommand),
                _ => throw new ArgumentException()
            };
        }
    }
}
