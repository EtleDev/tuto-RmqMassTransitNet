using MassTransit;

namespace EtleDev.Tutos.MassTransit.Receiver
{
    public class TrucService : IHostedService
    {
        private readonly ILogger<TrucService> _logger;
        private readonly IBusControl serviceBus;

        public TrucService(IBusControl busControl)
        {
            serviceBus = busControl;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return serviceBus.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return serviceBus.StopAsync(cancellationToken);
        }
    }
}
