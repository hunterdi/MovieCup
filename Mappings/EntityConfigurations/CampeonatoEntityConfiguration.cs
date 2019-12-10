using Domains;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mappings
{
	public class CampeonatoEntityConfiguration : IEntityTypeConfiguration<Campeonato>, IEntityMapping
	{
		public void Configure(EntityTypeBuilder<Campeonato> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.classificacao).IsRequired();
			builder.Property(e => e.campeonatoFilmes).IsRequired();
			builder.Property(e => e.nome).IsRequired();

			builder.HasMany(e => e.classificacao)
				.WithOne(e => e.campeonato)
				.HasForeignKey(e => e.Id);
		}
	}
}
