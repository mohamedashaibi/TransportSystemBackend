using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TransportSystem.Data;
using TransportSystem.IRepository;
using Microsoft.EntityFrameworkCore;

namespace TransportSystem.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly DatabaseContext _context;
		private readonly DbSet<T> _db;

		public GenericRepository(DatabaseContext context)
		{
			_context = context;
			_db = context.Set<T>();

		}

		public async Task Create(T entity)
		{
			await _db.AddAsync(entity);
		}

		public async Task CreateRange(IEnumerable<T> entities)
		{
			await _db.AddRangeAsync(entities);
		}

		public async Task Delete(int id)
		{
			var entity = await _db.FindAsync(id);
			_db.Remove(entity);
		}

		public void DeleteRange(IEnumerable<T> entities)
		{
			_db.RemoveRange(entities);
		}

		public Task<T> Get(Expression<Func<T, bool>> expression = null, List<string> includes = null)
		{
			IQueryable<T> query = _db;

			if(includes != null)
			{
				foreach(var include in includes)
				{
					query = query.Include(include);
				}
			}
			return query.AsNoTracking().FirstOrDefaultAsync(expression);
		}

		public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
		{
			IQueryable<T> query = _db;

			if (includes != null)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}

			if (orderBy != null)
			{
				query = orderBy(query);
			}

			if(expression != null)
			{
				query = query.Where(expression);
			}

			return await query.AsNoTracking().ToListAsync();
		}

		public void Update(T entity)
		{
			_db.Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
		}
	}
}
