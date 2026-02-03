using Microsoft.EntityFrameworkCore;

namespace Payout.Infrastructure.Data;

public class PayoutDbContext : DbContext
{
  public PayoutDbContext(DbContextOptions<PayoutDbContext> options) : base(options) { }

  // For now we’ll keep these empty so we can compile immediately.
  // Next steps will add DbSet<Partner>, DbSet<Sale>, etc.
  // public DbSet<Partner> Partners => Set<Partner>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    // Next steps: apply entity configurations here.
    // modelBuilder.ApplyConfigurationsFromAssembly(typeof(PayoutDbContext).Assembly);
  }
}
