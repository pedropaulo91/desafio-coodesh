using FitnessFoods.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessFoods.Infrastructure.Data.Context
{
    public class SqlServerContext: DbContext
    {

        public SqlServerContext(DbContextOptions<SqlServerContext> options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ImportHistory> ImportHistory { get; set; }

    }
}
