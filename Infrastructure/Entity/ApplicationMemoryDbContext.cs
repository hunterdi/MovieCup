using Domains;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
	public class ApplicationMemoryDbContext : DbContext, IMigrationContext
	{
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
