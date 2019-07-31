using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domains;
using Infrastructure;

namespace Services
{
	public interface ICampeonatoService: IServiceBase<Campeonato>
	{
		Task<Campeonato> GetFinalist(long id);
	}
}
