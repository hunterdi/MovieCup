using Autofac;
using Domains;
using Infrastructure;

namespace Repository
{
	public class RepositoryModule: Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			builder.RegisterType<FilmeRepository>().As<IFilmeRepository>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
			builder.RegisterType<FilmeRepository>().As<IRepositoryBase<Filme>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

			builder.RegisterType<CampeonatoRepository>().As<ICampeonatoRepository>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
			builder.RegisterType<CampeonatoRepository>().As<IRepositoryBase<Campeonato>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

			builder.RegisterType<ClassificacaoRepository>().As<IClassificacaoRepository>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
			builder.RegisterType<ClassificacaoRepository>().As<IRepositoryBase<Classificacao>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);


			builder.RegisterType<DisputaRepository>().As<IDisputaRepository>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
			builder.RegisterType<DisputaRepository>().As<IRepositoryBase<Disputa>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

			builder.RegisterType<LoggerRepository>().As<ILoggerRepository>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
			builder.RegisterType<LoggerRepository>().As<IRepositoryBase<EventLog>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

			builder.RegisterType<FilmeCampeonatoRepository>().As<IFilmeCampeonatoRepository>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
			builder.RegisterType<FilmeCampeonatoRepository>().As<IRepositoryBase<FilmeCampeonato>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

			builder.RegisterType<ApplicationUserRepository>().As<IApplicationUserRepository>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
			builder.RegisterType<ApplicationUserRepository>().As<IRepositoryBase<ApplicationUser>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
		}
	}
}
