using System.Transactions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Infrastructure
{
	public static class MvcCoreConfigurationExtension
	{
		public static IServiceCollection AddMvcCoreConfiguration(this IServiceCollection services, IsolationLevel level = IsolationLevel.ReadUncommitted)
		{
			services.AddMvcCore(options =>
			{
				options.RespectBrowserAcceptHeader = false;
				options.MaxModelValidationErrors = 10;
				options.OutputFormatters.RemoveType<TextOutputFormatter>();
				options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
				//options.OutputFormatters.RemoveType<JsonOutputFormatter>();
				options.Filters.Add(typeof(ValidateModelStateFilter));
			})
			.AddApiExplorer()
			//.AddJsonFormatters()
			.AddJsonOptions(jo =>
			{
                //jo.JsonSerializerOptions.ContractResolver = new DefaultContractResolver()
                //{
                //	NamingStrategy = new CamelCaseNamingStrategy()
                //};
                //jo.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                jo.JsonSerializerOptions.IgnoreNullValues = true;
                jo.JsonSerializerOptions.WriteIndented = true;
			})
			.AddFluentValidation(v => v.RegisterValidatorsFromAssemblyContaining<IValidatorBase>())
			.AddControllersAsServices()
			.SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

			return services;
		}
	}
}
