using Microsoft.EntityFrameworkCore;
using TheEstimator.Models;

namespace TheEstimator.DataContext;

public class EstimateContext : DbContext
{

    public EstimateContext(DbContextOptions<EstimateContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }

    public DbSet<Estimate> Estimates { get; set; }
}
