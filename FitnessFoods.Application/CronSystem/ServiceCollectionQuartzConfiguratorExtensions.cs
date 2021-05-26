using Microsoft.Extensions.Configuration;
using Quartz;

namespace FitnessFoods.Application.CronSystem
{
    public static class ServiceCollectionQuartzConfiguratorExtensions
    {
        public static void AddJobAndTrigger<T>(this IServiceCollectionQuartzConfigurator quartz,
                                                IConfiguration config)  where T : IJob
        {
            
            string jobName = typeof(T).Name;
            
            var configKey = $"Quartz:{jobName}";
            var cronSchedule = config[configKey];

            var jobKey = new JobKey(jobName);
            quartz.AddJob<T>(opts => opts.WithIdentity(jobKey));

            quartz.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity(jobName + "-trigger")
                .WithCronSchedule(cronSchedule)); 
        }
    }
}
