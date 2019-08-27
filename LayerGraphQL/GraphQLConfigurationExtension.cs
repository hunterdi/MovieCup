using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Server.Internal;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace LayerGraphQL
{
	public static class GraphQLConfigurationExtension
	{
		public static IServiceCollection AddConfigurationGraphQL(this IServiceCollection services)
		{
			services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
			services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
			services.AddSingleton<IDocumentWriter, DocumentWriter>();

			services.AddSingleton<CampeonatoType>();
			services.AddSingleton<ISchema, CampeonatoSchema>();
			services.AddSingleton<CampeonatoQuery>();

			services.AddSingleton<ClassificacaoType>();
			services.AddSingleton<ISchema, ClassificacaoSchema>();
			services.AddScoped<ClassificacaoQuery>();

			services.AddSingleton<DisputaType>();
			services.AddSingleton<ISchema, DisputaSchema>();
			services.AddScoped<DisputaQuery>();

			services.AddSingleton<FilmeCampeonatoType>();
			services.AddSingleton<ISchema, FilmeCampeonatoSchema>();
			services.AddScoped<FilmeCampeonatoQuery>();

			services.AddSingleton<FilmeType>();
			services.AddSingleton<ISchema, FilmeSchema>();
			services.AddScoped<FilmeQuery>();

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.AddGraphQl(options =>
			{
			}).AddDataLoader();
			services.AddTransient(typeof(IGraphQLExecuter<>), typeof(LayerGraphQLExecuter<>));

			return services;
		}

		public static IApplicationBuilder UseConfigurationGraphQL(this IApplicationBuilder builder)
		{
			builder.UseGraphQL<ISchema>("/api/graphql");

			builder.UseGraphQLPlayground(new GraphQLPlaygroundOptions
			{
				Path = "/ui/graphql",
				GraphQLEndPoint = "/api/graphql"
			});

			return builder;
		}
	}
}
