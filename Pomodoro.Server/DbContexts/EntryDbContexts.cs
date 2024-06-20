using Microsoft.EntityFrameworkCore;
using Pomodoro.Server.Models;

namespace Pomodoro.Server.DbContexts
{
    public class EntryDbContexts : DbContext
    {
        public DbSet<Entry> entries { get; set; }

        public DbSet<User> users { get; set; }

        public EntryDbContexts()
            {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configurationInstance = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)?.FullName ?? ".")
                   .AddJsonFile("appSettings.json", optional: true)
                   .Build();

            string dbConnString = configurationInstance["ConnectionStrings:EntryDb"] ?? "";
            optionsBuilder.UseNpgsql(dbConnString);
            base.OnConfiguring(optionsBuilder);
        }

    }
}
