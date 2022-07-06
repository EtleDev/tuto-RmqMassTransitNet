using EtleDev.Tutos.MassTransit.Core;
using MassTransit;

namespace EtleDev.Tutos.MassTransit.Receiver
{
    public class MachinConsumer : IConsumer<Machin>
    {
        private readonly ILogger<MachinConsumer> logger;
        public MachinConsumer(ILogger<MachinConsumer> logger)
        {
            this.logger = logger;
        }
        public async Task Consume(ConsumeContext<Machin> context)
        {
            try
            {
                logger.LogInformation(context.Message.Content);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
