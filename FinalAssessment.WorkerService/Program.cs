using FinalAssessment.WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Watermark>();
        services.AddHostedService<WeeklyReport>();
        services.AddHostedService<MonthlyReport>();
 
    })


 

    .Build();

await host.RunAsync();

 