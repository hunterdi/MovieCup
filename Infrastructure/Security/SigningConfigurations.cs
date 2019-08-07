using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure
{
	public class SigningConfigurations
	{
		public SecurityKey key { get; }
		public SigningCredentials signingCredentials { get; }

		public SigningConfigurations()
		{
			using (var provider = new RSACryptoServiceProvider(2048))
			{
				this.key = new RsaSecurityKey(provider.ExportParameters(true));
			}

			this.signingCredentials = new SigningCredentials(this.key, SecurityAlgorithms.RsaSha256Signature);
		}
	}
}
