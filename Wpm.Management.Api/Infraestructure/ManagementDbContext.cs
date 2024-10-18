using System;
using Microsoft.EntityFrameworkCore;
using Wpm.Management.Domain;

namespace Wpm.Management.Api.Infraestructure;

public class ManagementDbContext : DbContext
{
    public DbSet<Pet> Pets { get; set; }
    public ManagementDbContext(DbContextOptions options) : base(options){
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Pet>().HasKey(x => x.Id);
        modelBuilder.Entity<Pet>()
            .Property(p => p.BreedId)
            .HasConversion(v => v.Id, v => BreedId.Create(v));
        modelBuilder.Entity<Pet>().OwnsOne(x => x.Weight);
    }
}

public static class ManagementDbContexExtensions{
    public static void EnsureDbIsCreated(this IApplicationBuilder application){
        using var scope = application.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetService<ManagementDbContext>();
        context?.Database.EnsureCreated();
        context?.Database.CloseConnection();
    }
}
