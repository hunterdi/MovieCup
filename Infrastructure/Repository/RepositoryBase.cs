using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domains;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
	public abstract class RepositoryBase<TDomain, TContext> : IRepositoryBase<TDomain> where TDomain : class where TContext : DbContext
	{
		protected readonly TContext _dbContext;
		protected readonly DbSet<TDomain> _domainEntitySet;
		private bool disposed = false;

		public RepositoryBase(TContext dbContext)
		{
			this._dbContext = dbContext;
			this._domainEntitySet = this._dbContext.Set<TDomain>();
		}

		public IQueryable<TDomain> Pagination(Expression<Func<TDomain, bool>> filter, Expression<Func<TDomain, object>> orderBy, int pageSize, int pageIndex)
		{
			return this._domainEntitySet.Where(filter).OrderBy(orderBy).Skip(pageSize * pageIndex).Take(pageSize);
		}

		public async Task<Tuple<ICollection<TDomain>, int>> GetAllAsync(int skip, int take, Expression<Func<TDomain, bool>> where,
			Expression<Func<TDomain, object>> orderBy, bool asNoTracking = true)
		{
			var dataBaseCount = await this._domainEntitySet.CountAsync();
			if (asNoTracking)
			{
				return new Tuple<ICollection<TDomain>, int>(await this._domainEntitySet.AsNoTracking().Where(where).OrderBy(orderBy).Skip(skip).Take(take).ToListAsync(), dataBaseCount);
			}

			return new Tuple<ICollection<TDomain>, int>(await this._domainEntitySet.Where(where).OrderBy(orderBy).Skip(skip).Take(take).ToListAsync(), dataBaseCount);
		}

		public virtual async Task<ICollection<TDomain>> GetAllByAsync(Expression<Func<TDomain, bool>> match, bool asNoTracking = true)
		{
			if (asNoTracking)
				return await this._domainEntitySet.AsNoTracking().Where(match).ToListAsync();
			return await this._domainEntitySet.Where(match).ToListAsync();
		}

		public virtual IQueryable<TDomain> GetAllIncluding(bool asNoTracking = true, params Expression<Func<TDomain, object>>[] includeProperties)
		{
			IQueryable<TDomain> queryable = GetAll(asNoTracking);
			foreach (Expression<Func<TDomain, object>> includeProperty in includeProperties)
			{
				queryable = queryable.Include<TDomain, object>(includeProperty);
			}

			return queryable;
		}

		public virtual IQueryable<TDomain> GetByIncluding(Expression<Func<TDomain, bool>> match, bool asNoTracking = true, 
			params Expression<Func<TDomain, object>>[] includeProperties)
		{
			IQueryable<TDomain> queryable = GetAll(asNoTracking);
			foreach (Expression<Func<TDomain, object>> includeProperty in includeProperties)
			{
				queryable = queryable.Include<TDomain, object>(includeProperty);
			}

			return queryable.Where(match);
		}

		public virtual async Task<ICollection<TDomain>> GetAllIncludingAsync(bool asNoTracking = true, params Expression<Func<TDomain, object>>[] includeProperties)
		{
			return await GetAllIncluding(asNoTracking, includeProperties).ToListAsync();
		}

		public virtual async Task<ICollection<TDomain>> GetByIncludingAsync(Expression<Func<TDomain, bool>> match, bool asNoTracking = true, 
			params Expression<Func<TDomain, object>>[] includeProperties)
		{
			return await GetByIncluding(match, asNoTracking, includeProperties).ToListAsync();
		}

		public virtual IQueryable<TDomain> GetAll(bool asNoTracking = true)
		{
			if (asNoTracking)
				return this._domainEntitySet.AsNoTracking();

			return this._domainEntitySet;
		}

		public virtual async Task<ICollection<TDomain>> GetAllAsync(bool asNoTracking = true)
		{
			if (asNoTracking)
				return await this._domainEntitySet.AsNoTracking().ToListAsync();

			return await this._domainEntitySet.ToListAsync();
		}

		public virtual async Task<TDomain> GetByAsync(Expression<Func<TDomain, bool>> match, bool asNoTracking = true)
		{
			if (asNoTracking)
				return await this._domainEntitySet.AsNoTracking().FirstOrDefaultAsync(match);

			return await this._domainEntitySet.FirstOrDefaultAsync(match);
		}

		public virtual async Task<TDomain> GetByIdAsync(object id)
		{
			return await this._domainEntitySet.FindAsync(id);
		}

		public virtual TDomain GetById(object id)
		{
			return this._domainEntitySet.Find(id);
		}

		public virtual async Task CreateAsync(TDomain domain)
		{
			await this._domainEntitySet.AddAsync(domain);
		}

		public virtual void Create(TDomain domain)
		{
			this._dbContext.Add(domain);
		}

		public virtual async Task<ICollection<TDomain>> CreateAsync(ICollection<TDomain> domains)
		{
			await this._domainEntitySet.AddRangeAsync(domains);

			return domains;
		}

		public virtual IEnumerable<TDomain> CreateWithProxy(IEnumerable<TDomain> domains)
		{
			foreach (var domain in domains)
			{
				this._domainEntitySet.Add(domain);
				yield return domain;
			}
		}

		public virtual Task UpdateAsync(TDomain domain)
		{
			this._domainEntitySet.Update(domain);
			return Task.CompletedTask;
		}

		public virtual Task UpdateAsync(ICollection<TDomain> domains)
		{
			this._domainEntitySet.UpdateRange(domains);
			return Task.CompletedTask;
		}

		public virtual IEnumerable<TDomain> UpdateWithProxy(IEnumerable<TDomain> domains)
		{
			foreach (var domain in domains)
			{
				this._domainEntitySet.Update(domain);
				yield return domain;
			}
		}

		public virtual Task RemoveByAsync(Func<TDomain, bool> where)
		{
			this._domainEntitySet.RemoveRange(this._domainEntitySet.ToList().Where(where));
			return Task.CompletedTask;
		}

		public virtual Task RemoveAsync(TDomain domain)
		{
			this._domainEntitySet.Remove(domain);
			return Task.CompletedTask;
		}

		public virtual async Task<TDomain> RemoveByIdAsync(object id)
		{
			TDomain finded = await this._domainEntitySet.FindAsync(id);

			if (finded != null)
			{
				this._domainEntitySet.Remove(finded);
			}
			return finded;
		}

		public virtual async Task SaveChangesAsync()
		{
			await this._dbContext.SaveChangesAsync();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_dbContext.Dispose();
				}
				this.disposed = true;
			}
		}
	}
}
