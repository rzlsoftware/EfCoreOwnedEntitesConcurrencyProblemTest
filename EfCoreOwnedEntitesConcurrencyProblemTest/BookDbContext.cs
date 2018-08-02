using Microsoft.EntityFrameworkCore;

namespace EfCoreOwnedEntitesConcurrencyProblemTest
{
    public class BookDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(@"Server=.;Database=ReproEfCoreOwnedEntitesConcurrencyProblemTest;Trusted_Connection=True;MultipleActiveResultSets=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(b =>
                {
                    b.OwnsOne(a => a.Name);
                    b.Property(p => p.Rowversion).IsRowVersion();
                });
        }
    }
}
