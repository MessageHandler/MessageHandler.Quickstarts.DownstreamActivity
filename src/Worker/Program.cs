using MessageHandler.Quickstart.Contract;
using MessageHandler.Runtime;
using MessageHandler.Runtime.AtomicProcessing;
using Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddLogging();

        var serviceBusConnectionString = hostContext.Configuration.GetValue<string>("servicebusnamespace")
                                                ?? throw new Exception("No 'servicebusnamespace' was provided. Use User Secrets or specify via environment variable.");

        services.AddMessageHandler("consolehandler", runtimeConfiguration =>
        {
            runtimeConfiguration.AtomicProcessingPipeline(pipeline =>
            {
                pipeline.PullMessagesFrom(p => p.Queue(name: "control", serviceBusConnectionString));
                pipeline.DetectTypesInAssembly(typeof(ChangeConsoleColor).Assembly);
                pipeline.HandleMessagesWith<ConsoleColorHandler>();
            });
        });

    })
    .Build();

await host.RunAsync();