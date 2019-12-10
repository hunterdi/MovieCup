using Domains;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mappings
{
	public class FilmeEnittyConfiguration : IEntityTypeConfiguration<Filme>, IEntityMapping
	{
		public void Configure(EntityTypeBuilder<Filme> builder)
		{
			builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

			builder.Property(e => e.ano).IsRequired();
			builder.Property(e => e.nota).IsRequired();
			builder.Property(e => e.titulo).IsRequired();	
		}
	}
}
