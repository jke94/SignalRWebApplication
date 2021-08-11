using Microsoft.EntityFrameworkCore;
using RealTimeCharts_Server.Models;

namespace RealTimeCharts_Server.DabaseContext
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext(DbContextOptions <MyDatabaseContext> dabaseContext): base (dabaseContext)
        {

        }

        public DbSet<ChartModel> Charts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
        }
    }
}
