using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mappings
{
	public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>, IEntityMapping
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Ignore(p => p.Password);
			builder.Ignore(e => e.PhoneNumber);

			builder.HasMany(e => e.Claims)
				.WithOne(e => e.User)
				.HasForeignKey(uc => uc.UserId)
				.IsRequired();

			builder.HasMany(e => e.Logins)
				.WithOne(e => e.User)
				.HasForeignKey(ul => ul.UserId)
				.IsRequired();

			builder.HasMany(e => e.Tokens)
				.WithOne(e => e.User)
				.HasForeignKey(ut => ut.UserId)
				.IsRequired();

			builder.HasMany(e => e.UserRoles)
				.WithOne(e => e.User)
				.HasForeignKey(ur => ur.UserId)
				.IsRequired();

			builder.HasMany(e => e.Phones)
				.WithOne(e => e.Users)
				.HasForeignKey(e => e.UsersId)
				.IsRequired();
		}
	}
}
