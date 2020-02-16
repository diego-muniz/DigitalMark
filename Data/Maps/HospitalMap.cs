using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DigitalMark.Models;

namespace DigitalMark.Data.Maps 
{
  public class HospitalMap : IEntityTypeConfiguration<Hospital>
  {
    public void Configure(EntityTypeBuilder<Hospital> builder)
    {
      builder.ToTable("Hospital");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Nome).IsRequired().HasMaxLength(120).HasColumnType("varchar(256)");
      builder.Property(x => x.CNPJ).IsRequired().HasMaxLength(18).HasColumnType("varchar(18)");
      builder.Property(x => x.Cep).IsRequired().HasMaxLength(9).HasColumnType("varchar(9)");
      builder.Property(x => x.Logradouro).HasMaxLength(64).HasColumnType("varchar(64)");
      builder.Property(x => x.Complemento).HasMaxLength(64).HasColumnType("varchar(64)");
      builder.Property(x => x.Bairro).HasMaxLength(64).HasColumnType("varchar(64)");
      builder.Property(x => x.Localidade).HasMaxLength(64).HasColumnType("varchar(64)");
      builder.Property(x => x.UF).HasMaxLength(2).HasColumnType("varchar(2)");
    }
  }

}