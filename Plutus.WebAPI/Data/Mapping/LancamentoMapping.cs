using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plutus.WebAPI.Data.Entity;

namespace Plutus.WebAPI.Data.Mapping
{
    public class LancamentoMapping : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Historico).IsUnicode(false).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Valor).HasPrecision(15, 2);
        }
    }
}
