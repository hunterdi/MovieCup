using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mappings
{
	public class FilmeCampeonatoEntityConfiguration : IEntityTypeConfiguration<FilmeCampeonato>, IEntityMapping
	{
		public void Configure(EntityTypeBuilder<FilmeCampeonato> builder)
		{
			builder.HasKey(e => e.id);

			builder.HasOne(e => e.filme)
				.WithMany(e => e.filmesCampeonato)
				.HasForeignKey(e => e.id);

			builder.HasOne(e => e.campeonato)
				.WithMany(e => e.campeonatoFilmes)
				.HasForeignKey(e => e.id);
		}
	}
}
