using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure
{
	public class ApplicationMemoryDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long,
		ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>, IMigrationContext
	{
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<ApplicationUserPhones> ApplicationUserPhones { get; set; }
		public DbSet<Phone> Phones { get; set; }
		public DbSet<ApplicationRole> ApplicationRoles { get; set; }
		public DbSet<ApplicationUserClaim> ApplicationUserClaims { get; set; }
		public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
		public DbSet<ApplicationUserLogin> ApplicationUserLogins { get; set; }
		public DbSet<ApplicationRoleClaim> ApplicationRoleClaims { get; set; }
		public DbSet<ApplicationUserToken> ApplicationUserTokens { get; set; }
		public DbSet<Filme> Filmes { get; set; }
		public DbSet<Campeonato> Campeonatos { get; set; }
		public DbSet<Classificacao> Classificacoes { get; set; }
		public DbSet<Disputa> Disputas { get; set; }
		
		public ApplicationMemoryDbContext(DbContextOptions<ApplicationMemoryDbContext> dbContextOptions) : base(dbContextOptions)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityMapping).Assembly);
		}
	}
}
