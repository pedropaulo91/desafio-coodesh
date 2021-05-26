using FitnessFoods.Application.CronSystem;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Quartz;

namespace FitnessFoods.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddQuartz(q => {
                        
                        q.UseMicrosoftDependencyInjectionScopedJobFactory();

                        q.AddJobAndTrigger<OpenFoodFactsJob>(hostContext.Configuration);

                    });
                    services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
