using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mappings.EntityConfigurations
{
	public class ApplicationRoleEntityConfiguration : IEntityTypeConfiguration<ApplicationRole>, IEntityMapping
	{
		public void Configure(EntityTypeBuilder<ApplicationRole> builder)
		{
			builder.HasMany(e => e.UserRoles)
				.WithOne(e => e.Role)
				.HasForeignKey(ur => ur.RoleId)
				.IsRequired();

			builder.HasMany(e => e.RoleClaims)
				.WithOne(e => e.Role)
				.HasForeignKey(rc => rc.RoleId)
				.IsRequired();
		}
	}
}
