using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.DatabaseContext;

public class DatabaseContext : DbContext 
{
    public DatabaseContext(DbContextOptions options) : base(options) 
    {
    }

    public DbSet<ProjectServicesEntity> ProjectServices { get; set; } = default!;
    public DbSet<ProjectsEntity> Projects { get; set; } = default!;
    public DbSet<ProjectsCategory> ProjectsCategory { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectsEntity>(x => 
            {
                x.HasMany(x => x.Services)
                .WithOne(x => x.Project)
                .HasForeignKey(x => x.Project_Id);

                x.HasOne(x => x.Category)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.Category_Id);
            }
        );
    }
}