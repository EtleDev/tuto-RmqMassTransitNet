using EtleDev.Tutos.MassTransit.Receiver;
using MassTransit;
using System.Reflection;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(x =>
         {
             x.AddConsumers(Assembly.GetEntryAssembly());

             x.UsingRabbitMq((context, cfg) =>
             {
                 cfg.Host("amqp://admin:r00t@mt_rmq");

                 //cfg.UseMessageRetry(mr => mr.Exponential(3, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(30), TimeSpan.FromSeconds(10)));

                 cfg.ReceiveEndpoint("truc-receiver", e =>
                 {
                     e.ConfigureConsumers(context);
                 });
             });
         });
        services.AddHostedService<TrucService>();
    })
    .Build();

await host.RunAsync();
