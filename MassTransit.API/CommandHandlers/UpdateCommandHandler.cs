using MassTransit.API.Commands;
using System.Threading.Tasks;

namespace MassTransit.API.CommandHandlers
{
    public class UpdateCommandHandler : IConsumer<UpdateCommand>
    {
        public Task Consume(ConsumeContext<UpdateCommand> context)
        {
            throw new System.NotImplementedException();
        }
    }
}
