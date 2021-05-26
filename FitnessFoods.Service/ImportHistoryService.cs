using FitnessFoods.Domain.Entities;
using FitnessFoods.Infrastructure.Data.Repository;
using FitnessFoods.Infrastructure.Data.Repository.Interfaces;
using FitnessFoods.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessFoods.Service
{
    public class ImportHistoryService: IImportHistoryService
    {
        private readonly IImportHistoryRepository _repository;

        public ImportHistoryService(IImportHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImportHistory> GetHistory()
        {
            return await _repository.GetHistory();
        }

        public async Task InserHistory(ImportHistory history)
        {
            await _repository.InsertHistory(history);
        }

    }
}
