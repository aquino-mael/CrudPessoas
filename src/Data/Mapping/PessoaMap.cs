using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaEntity> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Email)
                   .IsUnique();

            builder.Property(p => p.Email)
                   .HasMaxLength(100);

            builder.HasIndex(p => p.DocumentNumber)
                   .IsUnique();

            builder.Property(p => p.DocumentNumber)
                   .IsRequired()
                   .HasMaxLength(14);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(60);
        }
    }
}
