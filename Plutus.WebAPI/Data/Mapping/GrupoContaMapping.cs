using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plutus.WebAPI.Data.Entity;

namespace Plutus.WebAPI.Data.Mapping
{
    public class GrupoContaMapping : IEntityTypeConfiguration<GrupoConta>
    {
        public void Configure(EntityTypeBuilder<GrupoConta> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao).IsUnicode(false).HasMaxLength(250).IsRequired();
        }
    }
}
