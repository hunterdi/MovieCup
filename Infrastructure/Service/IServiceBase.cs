using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domains;

namespace Infrastructure
{
	public interface IServiceBase<TDomain> where TDomain : BaseDomain
	{
		TDomain Create(TDomain obj);
		Task CreateAsync(TDomain obj);
		IEnumerable<TDomain> CreateCollectionWithProxy(IEnumerable<TDomain> domains);
		Task<ICollection<TDomain>> CreateCollectionAsync(ICollection<TDomain> domains);
		void Remove(object id);
		Task<int> RemoveAsync(object id);
		TDomain Get(Expression<Func<TDomain, bool>> match);
		Task<TDomain> GetAsync(Expression<Func<TDomain, bool>> match);
		ICollection<TDomain> GetAll(Expression<Func<TDomain, bool>> match);
		Task<ICollection<TDomain>> GetAllAsync(Expression<Func<TDomain, bool>> match);
		IQueryable<TDomain> GetBy(Expression<Func<TDomain, bool>> predicate);
		Task<ICollection<TDomain>> GetByAsync(Expression<Func<TDomain, bool>> predicate);
		TDomain GetById(object id);
		Task<TDomain> GetByIdAsync(object id);
		IQueryable<TDomain> GetAll();
		Task<ICollection<TDomain>> GetAllAsync();
		Task<ICollection<TDomain>> GetAllByAsync(Expression<Func<TDomain, bool>> match, bool asNoTracking = true);
		IQueryable<TDomain> GetAllIncluding(params Expression<Func<TDomain, object>>[] includeProperties);
		Task<ICollection<TDomain>> GetAllIncludingAsync(params Expression<Func<TDomain, object>>[] includeProperties);
		Task<ICollection<TDomain>> GetByIncludingAsync(Expression<Func<TDomain, bool>> match, bool asNoTracking = true, params Expression<Func<TDomain, object>>[] includeProperties);
		TDomain Update(TDomain obj, object key);
		Task<TDomain> UpdateAsync(TDomain obj, object key);
	}
}
