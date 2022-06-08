using Mecanillama.API.Appointments.Domain.Models;
using Mecanillama.API.Customers.Domain.Model;
using Mecanillama.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Mecanillama.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){}
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //Customers
        builder.Entity<Customer>().ToTable("Customers");
        builder.Entity<Customer>().HasKey(p => p.Id);
        builder.Entity<Customer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Customer>().Property(p => p.Name).IsRequired().HasMaxLength(40);
        builder.Entity<Customer>().Property(p => p.Email).IsRequired().HasMaxLength(40);
        builder.Entity<Customer>().Property(p => p.Password).IsRequired().HasMaxLength(40);
        builder.Entity<Customer>().Property(p => p.CarMake).IsRequired().HasMaxLength(40);
        builder.Entity<Customer>().Property(p => p.Address).IsRequired().HasMaxLength(40);
        
        //Relationships
        builder.Entity<Customer>().
            HasMany(p => p.Appointments).WithOne(p => p.Customer)
            .HasForeignKey(p => p.CustomerId);
        
        //Mechanics
        //builder.Entity<Mechanic>().ToTable("Mechanics");
        //builder.Entity<Mechanic>(HasKey)(p => p.Id);
        
        //Relationships
        
        //Appointments
        
        //Relationships
        
        //Reviews
        
        //Relationships
        
        //Snake Case Conventions
        
        builder.UseSnakeCaseNamingConvention();


    }

}