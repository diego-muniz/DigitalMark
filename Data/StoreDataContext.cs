using Microsoft.EntityFrameworkCore;
using DigitalMark.Models;
using DigitalMark.Data.Maps;

namespace DigitalMark.Data 
{
  public class StoreDataContext : DbContext 
  {
    public DbSet<Hospital> Hospital {get; set;}
    public DbSet<Enfermeiro> Enfermeiro {get; set;}
    public DbSet<HospitalEnfermeiro> HospitalEnfermeiro {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
      //  optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=DigitalMarkDEV; User ID=SA; Password=Teste*123");
       optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=AgenciaDigitalMarkDEV; User ID=SA; Password=Teste*123");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        // builder.ApplyConfiguration(new EnfermeiroMap());
        // builder.ApplyConfiguration(new HospitalMap());

            modelBuilder.Entity<HospitalEnfermeiro>()
                .HasOne(x => x.Enfermeiro)
                .WithMany(x => x.HospitalEnfermeiro)
                .HasForeignKey(x => x.EnfermeiroId);

            modelBuilder.Entity<HospitalEnfermeiro>()
                .HasOne(x => x.Hospital)
                .WithMany(x => x.HospitalEnfermeiro)
                .HasForeignKey(x => x.HospitalId);

            base.OnModelCreating(modelBuilder);
    }
  }
}