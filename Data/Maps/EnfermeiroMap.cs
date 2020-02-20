using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DigitalMark.Models;

namespace DigitalMark.Data.Maps 
{
  public class EnfermeiroMap : IEntityTypeConfiguration<Enfermeiro>
  {
    public void Configure(EntityTypeBuilder<Enfermeiro> builder)
    {
      builder.ToTable("Enfermeiro");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Nome).IsRequired().HasMaxLength(128).HasColumnType("varchar(128)");
      builder.Property(x => x.Coren).IsRequired().HasMaxLength(19).HasColumnType("varchar(19)");
      builder.Property(x => x.DataNascimento).IsRequired();
    }
  }

}