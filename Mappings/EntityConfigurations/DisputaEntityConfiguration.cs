using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mappings
{
	public class DisputaEntityConfiguration : IEntityTypeConfiguration<Disputa>, IEntityMapping
	{
		public void Configure(EntityTypeBuilder<Disputa> builder)
		{
			builder.HasKey(e => e.id);

			builder.Property(e => e.vencedor).IsRequired();
		}
	}
}
