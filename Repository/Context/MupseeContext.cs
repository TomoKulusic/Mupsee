//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Repository.Entities;

namespace Repository.Context
{
    public class MupseeContext : DbContext
    {
        public MupseeContext(DbContextOptions<MupseeContext> options) : base(options) { }


        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<MovieTrailers> MovieTrailers { get; set; }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MupseeContext>
    {
        public MupseeContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../Mupsee/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<MupseeContext>();
            var connectionString = configuration.GetConnectionString("MupseeConnectionString");
            builder.UseSqlServer(connectionString);
            return new MupseeContext(builder.Options);
        }
    }
}

