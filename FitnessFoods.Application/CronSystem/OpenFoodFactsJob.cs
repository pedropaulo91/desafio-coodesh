using FitnessFoods.Service.Interfaces;
using Microsoft.Extensions.Logging;
using Quartz;
using System.Threading.Tasks;

namespace FitnessFoods.Application.CronSystem
{
    [DisallowConcurrentExecution]
    public class OpenFoodFactsJob : IJob
    {

        private readonly IOpenFoodsFactsService _helper;

        public OpenFoodFactsJob(ILogger<OpenFoodFactsJob> logger, IOpenFoodsFactsService helper)
        {
            _helper = helper;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _helper.ImportData();   
        }
    }
}
