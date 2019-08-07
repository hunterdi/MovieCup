using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domains;

namespace Infrastructure
{
	public abstract class ServiceBase<TDomain> : IServiceBase<TDomain> where TDomain : class
	{
		protected readonly IRepositoryBase<TDomain> _repositoryBase;

		public ServiceBase(IRepositoryBase<TDomain> repositoryBase)
		{
			this._repositoryBase = repositoryBase;
		}

		public TDomain Get(Expression<Func<TDomain, bool>> match)
		{
			throw new NotImplementedException();
		}

		public ICollection<TDomain> GetAll(Expression<Func<TDomain, bool>> match)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<TDomain>> GetAllAsync(Expression<Func<TDomain, bool>> match)
		{
			throw new NotImplementedException();
		}

		public Task<TDomain> GetAsync(Expression<Func<TDomain, bool>> match)
		{
			throw new NotImplementedException();
		}

		public IQueryable<TDomain> GetBy(Expression<Func<TDomain, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<TDomain>> GetByAsync(Expression<Func<TDomain, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public virtual async Task<ICollection<TDomain>> GetAllByAsync(Expression<Func<TDomain, bool>> match, bool asNoTracking = true)
		{
			return await this._repositoryBase.GetAllByAsync(match, asNoTracking);
		}

		public IQueryable<TDomain> GetAll()
		{
			throw new NotImplementedException();
		}

		public async Task<ICollection<TDomain>> GetAllAsync()
		{
			return await this._repositoryBase.GetAllAsync();
		}

		public IQueryable<TDomain> GetAllIncluding(params Expression<Func<TDomain, object>>[] includeProperties)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<TDomain>> GetAllIncludingAsync(params Expression<Func<TDomain, object>>[] includeProperties)
		{
			throw new NotImplementedException();
		}

		public virtual async Task<ICollection<TDomain>> GetByIncludingAsync(Expression<Func<TDomain, bool>> match, bool asNoTracking = true, params Expression<Func<TDomain, object>>[] includeProperties)
		{
			return await this._repositoryBase.GetByIncludingAsync(match, asNoTracking, includeProperties);
		}

		public TDomain GetById(object id)
		{
			return this._repositoryBase.GetById(id);
		}

		public Task<TDomain> GetByIdAsync(object id)
		{
			throw new NotImplementedException();
		}

		public virtual TDomain Create(TDomain obj)
		{
			throw new NotImplementedException();
		}

		public virtual async Task CreateAsync(TDomain obj)
		{
			await this._repositoryBase.CreateAsync(obj);
		}

		public virtual IEnumerable<TDomain> CreateCollectionWithProxy(IEnumerable<TDomain> domains)
		{
			return this._repositoryBase.CreateCollectionWithProxy(domains);
		}

		public virtual async Task<ICollection<TDomain>> CreateCollectionAsync(ICollection<TDomain> domains)
		{
			return await this._repositoryBase.CreateCollectionAsync(domains);
		}

		public virtual TDomain Update(TDomain obj, object key)
		{
			throw new NotImplementedException();
		}

		public virtual async Task<TDomain> UpdateAsync(TDomain obj, object key)
		{
			await this._repositoryBase.UpdateAsync(obj);

			await this._repositoryBase.SaveChangesAsync();

			return obj;
		}

		public virtual void Remove(object id)
		{
			throw new NotImplementedException();
		}

		public virtual Task<int> RemoveAsync(object id)
		{
			throw new NotImplementedException();
		}

	}
}
