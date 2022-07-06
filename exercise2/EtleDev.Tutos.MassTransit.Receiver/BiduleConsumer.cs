using EtleDev.Tutos.MassTransit.Core;
using MassTransit;

namespace EtleDev.Tutos.MassTransit.Receiver
{
    public class BiduleConsumer : IConsumer<Bidule>
    {
        private readonly ILogger<BiduleConsumer> logger;
        public BiduleConsumer(ILogger<BiduleConsumer> logger)
        {
            this.logger = logger;
        }
        public async Task Consume(ConsumeContext<Bidule> context)
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
