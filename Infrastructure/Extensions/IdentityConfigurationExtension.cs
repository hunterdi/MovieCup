using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Domains;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 6;
				options.Password.RequireLowercase = true;
				options.Password.RequireUppercase = true;
				options.Password.RequireNonAlphanumeric = true;

				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.AllowedForNewUsers = true;

				options.User.RequireUniqueEmail = true;
				options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
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

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(bearerOptions =>
			{
				//Remove the comment bellow case don't needing send the token of the client to server
				//bearerOptions.RequireHttpsMetadata = false;
				//bearerOptions.SaveToken = true;
				bearerOptions.TokenValidationParameters.IssuerSigningKey = signingConfigurations.key;
				bearerOptions.TokenValidationParameters.ValidAudience = tokenConfigurations.Audience;
				bearerOptions.TokenValidationParameters.ValidIssuer = tokenConfigurations.Issuer;
				bearerOptions.TokenValidationParameters.ValidateIssuerSigningKey = true;
				bearerOptions.TokenValidationParameters.ValidateLifetime = true;
				bearerOptions.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
			}).AddCookiesTokienConfiguration();
			
			services.AddAuthorization(auth =>
			{
				auth.AddPolicy("Santander.Api.Precla", policy =>
				{
					policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
					policy.RequireAuthenticatedUser();
				});
			});

			return services;
		}

		public static AuthenticationBuilder AddCookiesTokienConfiguration(this AuthenticationBuilder authenticationBuilder)
		{
			authenticationBuilder.AddCookie(options =>
			 {
				 options.Cookie.SameSite = SameSiteMode.None;
				 options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
				 options.Cookie.HttpOnly = true;
				 options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

				 options.AccessDeniedPath = new PathString("/authentication");
				 options.LoginPath = new PathString("/authentication");
				 options.LogoutPath = new PathString("/authentication/sign-out");
				 options.SlidingExpiration = true;

				 options.Events = new CookieAuthenticationEvents { OnValidatePrincipal = SecurityStampValidator.ValidatePrincipalAsync };
			 });

			return authenticationBuilder;
		}
	}
}
