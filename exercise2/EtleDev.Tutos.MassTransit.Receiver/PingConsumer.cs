using EtleDev.Tutos.MassTransit.Core;
using MassTransit;

namespace EtleDev.Tutos.MassTransit.Receiver
{
    public class PingConsumer : IConsumer<Ping>
    {
        public async Task Consume(ConsumeContext<Ping> context)
        {
            try
            {
                var pong = new Pong { Id = Guid.NewGuid(), Date = DateTime.Now, PingId = context.Message.Id };
                await context.RespondAsync(pong);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
