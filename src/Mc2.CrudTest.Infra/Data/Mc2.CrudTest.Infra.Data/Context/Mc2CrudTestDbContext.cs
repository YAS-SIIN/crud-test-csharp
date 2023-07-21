
using Mc2.CrudTest.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infra.Data.Context;

public class Mc2CrudTestDbContext : DbContext
{
    public Mc2CrudTestDbContext(DbContextOptions<Mc2CrudTestDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CustomerEntityTypeConfiguration().Configure(modelBuilder.Entity<Customer>()); 
         
        modelBuilder.Entity<Customer>().HasIndex(b => new { b.Firstname, b.Lastname, b.DateOfBirth }).IsUnique();

        modelBuilder.Entity<Customer>().HasIndex(b => b.Email).IsUnique();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Mc2CrudTestDbContext).Assembly); base.OnModelCreating(modelBuilder);
    }


    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreateDateTime") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreateDateTime").CurrentValue = DateTime.Now;
                continue;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("CreateDateTime").IsModified = false;
                entry.Property("UpdateDateTime").CurrentValue = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }       

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreateDateTime") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreateDateTime").CurrentValue = DateTime.Now;
                continue;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("CreateDateTime").IsModified = false;
                entry.Property("UpdateDateTime").CurrentValue = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }


}