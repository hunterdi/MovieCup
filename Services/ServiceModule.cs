using Autofac;
using Domains;
using Infrastructure;

namespace Services
{
	public class ServiceModule: Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<FilmeService>().As<IFilmeService>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
			builder.RegisterType<FilmeService>().As<IServiceBase<Filme>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

			builder.RegisterType<CampeonatoService>().As<ICampeonatoService>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
			builder.RegisterType<CampeonatoService>().As<IServiceBase<Campeonato>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

			builder.RegisterType<ClassificacaoService>().As<IClassificacaoService>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
			builder.RegisterType<ClassificacaoService>().As<IServiceBase<Classificacao>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

			builder.RegisterType<DisputaService>().As<IDisputaService>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
			builder.RegisterType<DisputaService>().As<IServiceBase<Disputa>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

			builder.RegisterType<FilmeCampeonatoService>().As<IFilmeCampeonatoService>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
			builder.RegisterType<FilmeCampeonatoService>().As<IServiceBase<FilmeCampeonato>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
		}
	}
}
