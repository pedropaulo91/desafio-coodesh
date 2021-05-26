using FitnessFoods.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessFoods.Service.Interfaces
{
    public interface IImportHistoryService
    {

        Task<ImportHistory> GetHistory();
        Task InserHistory(ImportHistory history);

    }
}
