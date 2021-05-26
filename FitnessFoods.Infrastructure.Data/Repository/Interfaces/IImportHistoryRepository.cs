using FitnessFoods.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessFoods.Infrastructure.Data.Repository.Interfaces
{
    public interface IImportHistoryRepository
    {
        Task<ImportHistory> GetHistory();
        Task InsertHistory(ImportHistory history);
    }
}
