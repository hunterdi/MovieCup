using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Domains;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure
{
	public static class IdentityConfigurationExtension
	{
		public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
		{
			services.AddIdentity<ApplicationUser, ApplicationRole>()
				.AddSignInManager()
				.AddEntityFrameworkStores<ApplicationMemoryDbContext>()
				.AddDefaultTokenProviders();

			services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequiredLength = 5;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.User.RequireUniqueEmail = true;
				options.Lockout.MaxFailedAccessAttempts = 3;
			});

			return services;
		}

		public static object GenerateToken(this ApplicationUser user, TokenConfigurations tokenConfigurations, SigningConfigurations signingConfigurations)
		{
			ClaimsIdentity identity = new ClaimsIdentity(
					new GenericIdentity(user.Email),
					new[] {
						new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
						new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
					}
				);

			DateTime dataCriacao = DateTime.Now;
			DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

			var handler = new JwtSecurityTokenHandler();
			var securityToken = handler.CreateToken(new SecurityTokenDescriptor
			{
				Issuer = tokenConfigurations.Issuer,
				Audience = tokenConfigurations.Audience,
				SigningCredentials = signingConfigurations.signingCredentials,
				Subject = identity,
				NotBefore = dataCriacao,
				Expires = dataExpiracao
			});

			return new
			{
				authenticated = true,
				created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
				expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
				accessToken = handler.WriteToken(securityToken),
			};
		}

		public static IServiceCollection AddTokenConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			var signingConfigurations = new SigningConfigurations();
			services.AddSingleton(signingConfigurations);

			var tokenConfigurations = new TokenConfigurations();
			new ConfigureFromConfigurationOptions<TokenConfigurations>(configuration.GetSection("Jwt")).Configure(tokenConfigurations);
			services.AddSingleton(tokenConfigurations);

			services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddAuthentication(option =>
			{
				option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(bearerOptions =>
			{
				var paramsValidation = bearerOptions.TokenValidationParameters;
				paramsValidation.IssuerSigningKey = signingConfigurations.key;
				paramsValidation.ValidAudience = tokenConfigurations.Audience;
				paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
				paramsValidation.ValidateIssuerSigningKey = true;
				paramsValidation.ValidateLifetime = true;
				paramsValidation.ClockSkew = TimeSpan.Zero;
			})
			.AddCookie(options =>
			{
				options.Cookie.SameSite = SameSiteMode.Strict;
				options.Cookie.SecurePolicy = CookieSecurePolicy.Always;

				options.AccessDeniedPath = new PathString("/authentication");
				options.ExpireTimeSpan = TimeSpan.FromHours(4);
				options.LoginPath = new PathString("/authentication");
				options.LogoutPath = new PathString("/authentication/sign-out");

				options.Events = new CookieAuthenticationEvents { OnValidatePrincipal = SecurityStampValidator.ValidatePrincipalAsync };
			});
			//IdentityConstants

			//services.TryAddScoped<IdentityErrorDescriber>();
			//services.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
			//services.TryAddScoped<IPasswordHasher<ApplicationUser>, PasswordHasher<ApplicationUser>>();
			//services.TryAddScoped<IPasswordValidator<ApplicationUser>, PasswordValidator<ApplicationUser>>();
			//services.TryAddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, UserClaimsPrincipalFactory<ApplicationUser>>();
			//services.TryAddScoped<UserManager<ApplicationUser>>();
			////services.TryAddScoped<IUserStore<ApplicationUser>, ApplicationUserStore>();
			//services.TryAddScoped<IUserValidator<ApplicationUser>, UserValidator<ApplicationUser>>();
			//services.TryAddScoped<ISecurityStampValidator, SecurityStampValidator<ApplicationUser>>();
			//services.TryAddScoped<SignInManager<ApplicationUser>>();

			services.AddAuthorization(auth =>
			{
				auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
					.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
					.RequireAuthenticatedUser().Build());
			});

			return services;
		}
	}
}
