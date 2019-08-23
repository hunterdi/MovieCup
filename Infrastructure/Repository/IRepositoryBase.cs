using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domains;

namespace Infrastructure
{
	public interface IRepositoryBase<TDomain> where TDomain : class
	{
		IQueryable<TDomain> Pagination(Expression<Func<TDomain, bool>> filter, Expression<Func<TDomain, object>> orderBy, int pageSize, int pageIndex);

		Task<Tuple<ICollection<TDomain>, int>> GetAllAsync(int skip, int take, Expression<Func<TDomain, bool>> where,
			Expression<Func<TDomain, object>> orderBy, bool asNoTracking = true);

		Task<ICollection<TDomain>> GetAllByAsync(Expression<Func<TDomain, bool>> match, bool asNoTracking = true);

		Task<ICollection<TDomain>> GetAllIncludingAsync(bool asNoTracking = true, params Expression<Func<TDomain, object>>[] includeProperties);

		IQueryable<TDomain> GetByIncluding(Expression<Func<TDomain, bool>> match, bool asNoTracking = true, params Expression<Func<TDomain, object>>[] includeProperties);

		Task<ICollection<TDomain>> GetByIncludingAsync(Expression<Func<TDomain, bool>> match, bool asNoTracking = true, 
			params Expression<Func<TDomain, object>>[] includeProperties);

		IQueryable<TDomain> GetAll(bool asNoTracking = true);

		Task<ICollection<TDomain>> GetAllAsync(bool asNoTracking = true);

		Task<TDomain> GetByAsync(Expression<Func<TDomain, bool>> match, bool asNoTracking = true);

		Task<TDomain> GetByIdAsync(object id);

		TDomain GetById(object id);

		void Create(TDomain domain);

		Task CreateAsync(TDomain domain);

		Task<ICollection<TDomain>> CreateAsync(ICollection<TDomain> domains);

		IEnumerable<TDomain> CreateWithProxy(IEnumerable<TDomain> domains);

		Task UpdateAsync(TDomain domain);

		Task UpdateAsync(ICollection<TDomain> domains);

		IEnumerable<TDomain> UpdateWithProxy(IEnumerable<TDomain> domains);

		Task RemoveByAsync(Func<TDomain, bool> where);

		Task RemoveAsync(TDomain domain);

		Task<TDomain> RemoveByIdAsync(object id);

		Task SaveChangesAsync();

		void Dispose();
	}
}
