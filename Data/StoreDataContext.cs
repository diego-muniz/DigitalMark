using Microsoft.EntityFrameworkCore;
using DigitalMark.Models;
using DigitalMark.Data.Maps;

namespace DigitalMark.Data 
{
  public class StoreDataContext : DbContext 
  {
    public DbSet<Hospital> Hospital {get; set;}
    public DbSet<Enfermeiro> Enfermeiro {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
       optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=DigitalMarkDEV; User ID=SA; Password=Teste*123");
    }

    protected override void OnModelCreating(ModelBuilder builder) 
    {
        builder.ApplyConfiguration(new EnfermeiroMap());
        builder.ApplyConfiguration(new HospitalMap());
    }
  }
}