using FitnessFoods.Domain.Entities;
using FitnessFoods.Infrastructure.Data.Context;
using FitnessFoods.Infrastructure.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessFoods.Infrastructure.Data.Repository
{
    public class ImportHistoryRepository: IImportHistoryRepository
    {
        private readonly SqlServerContext _context;

        public ImportHistoryRepository(SqlServerContext context)
        {
            _context = context;
        }

        
        public async Task<ImportHistory> GetHistory()
        {
            return await _context.ImportHistory.AsNoTracking().Where(h => h.Failure == false).OrderBy(h => h.Time).LastOrDefaultAsync();
        }

        public async Task InsertHistory(ImportHistory history)
        {
            _context.ImportHistory.Add(history);
            await _context.SaveChangesAsync();
        }


    }
}
