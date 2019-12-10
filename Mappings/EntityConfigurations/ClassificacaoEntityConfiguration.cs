using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mappings
{
	public class ClassificacaoEntityConfiguration: IEntityTypeConfiguration<Classificacao>, IEntityMapping
	{
		public void Configure(EntityTypeBuilder<Classificacao> builder)
		{
			builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.campeonato).IsRequired();
			
			builder.HasMany(e => e.disputa)
				.WithOne(e => e.classificacao)
				.HasForeignKey(e => e.Id);
		}
	}
}
