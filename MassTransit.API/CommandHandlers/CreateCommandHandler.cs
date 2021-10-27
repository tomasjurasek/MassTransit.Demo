using MassTransit.API.Commands;
using System.Threading.Tasks;

namespace MassTransit.API.CommandHandlers
{
    public class CreateCommandHandler : IConsumer<CreateCommand>
    {
        public Task Consume(ConsumeContext<CreateCommand> context)
        {
            throw new System.NotImplementedException();
        }
    }
}
