﻿namespace AirportEf.DAL.Repositories
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Net;
	using System.Threading.Tasks;

	using Airport.Common.Interfaces.Entities;
	using Airport.Common.Services;

	using AirportEf.DAL.Data;
	using AirportEf.DAL.Interfaces.Repositories;

	using AutoMapper;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Query;

	/// <summary>
	/// Base Generic Repository
	/// </summary>
	/// <typeparam name="TEntity">
	/// Create DbSet<TEntity/> that you will work with
	/// </typeparam>
	/// <typeparam name="TKey">
	/// type of Id of your Entity that inherits from IEntity
	/// </typeparam>
	public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> // , IDisposable
													where TEntity : class, IEntity<TKey>
	{
		protected readonly AirportDbContext Context;
		protected readonly DbSet<TEntity> DbSet;

		protected readonly IMapper mapper;

		public Repository(AirportDbContext context, IMapper autoMappermapper)
		{
			Context = context;
			DbSet = Context.Set<TEntity>();
			mapper = autoMappermapper;
		}

		public async Task<TEntity> CreateAsync(TEntity entity)
		{
			await DbSet.AddAsync(entity).ConfigureAwait(false);

			return entity;
		}

		public Task CreateManyAsync(ICollection<TEntity> items)
		{
			return DbSet.AddRangeAsync(items);
		}

		public async Task<List<TEntity>> GetRangeAsync(int index = 1,
													   int count = 3,
													   Expression<Func<TEntity, bool>> filter = null,
													   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
													   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
													   bool disableTracking = true)
		{
			IQueryable<TEntity> query = DbSet;

			if (disableTracking)
			{
				query = query.AsNoTracking();
			}

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (include != null)
			{
				query = include(query);
			}

			if (orderBy == null)
			{
				query = query.OrderBy(a => a.Id);
			}
			else
			{
				query = orderBy(query);
			}

			if (index == 0) index = 1;
			if (count == 0) count = 3;

			return await query.Skip((index - 1) * count).Take(count).ToListAsync().ConfigureAwait(false);
		}

		/// <summary>
		/// Gets the first or default entity based on a predicate, orderby delegate and include delegate. This method default no-tracking query.
		/// </summary>
		/// <param name="predicate">
		/// A function to test each element for a condition.
		/// </param>
		/// <param name="orderBy">
		/// A function to order elements.
		/// </param>
		/// <param name="include">
		/// A function to include navigation properties
		/// </param>
		/// <param name="disableTracking">
		/// <c>True</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>.
		/// </param>
		/// <returns>
		/// An that contains elements that satisfy the condition specified by <paramref name="predicate"/>.
		/// </returns>
		/// <remarks>
		/// This method default no-tracking query.
		/// </remarks>
		public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
														  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
														  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
														  bool disableTracking = true)
		{
			IQueryable<TEntity> query = DbSet;
			if (disableTracking)
			{
				query = query.AsNoTracking();
			}

			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			if (include != null)
			{
				query = include(query);
			}

			if (orderBy != null)
			{
				return await orderBy(query).FirstOrDefaultAsync().ConfigureAwait(false);
			}

			return await query.FirstOrDefaultAsync().ConfigureAwait(false);
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			var findEntity = await DbSet.FindAsync(entity.Id).ConfigureAwait(false);

			if (findEntity == null)
			{
				throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Entity {entity.GetType().Name} with id: {entity.Id} not found");
			}

			return Mapper.Map(entity, findEntity);
		}

		public async Task<TEntity> UpdateAsync(TEntity entity,
											   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
		{
			IQueryable<TEntity> query = DbSet;

			if (include != null)
			{
				query = include(query);
			}

			var findEntity = await query.FirstOrDefaultAsync(e => e.Id.Equals(entity.Id)).ConfigureAwait(false);
			if (findEntity == null)
			{
				throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Entity {entity.GetType().Name} with id: {entity.Id} not found");
			}

			return Mapper.Map(entity, findEntity);
		}

		public TEntity Update(TEntity entity)
		{
			var entityEntry = DbSet.Update(entity);
			if (entityEntry == null)
			{
				throw new HttpStatusCodeException(HttpStatusCode.InternalServerError, "Entity " + entity.GetType().Name + " was not updated");
			}

			return entityEntry.Entity;
		}

		public async Task DeleteAsync(TKey id)
		{
			var entityToDelete = await DbSet.FindAsync(id).ConfigureAwait(false);
			if (entityToDelete == null)
			{
				throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Entity with id: {id} not found when trying to update entity. Entity was no Deleted.");
			}

			Delete(entityToDelete);
		}

		public async Task DeleteAsync(TKey id,
									  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
		{
			IQueryable<TEntity> query = DbSet;

			if (include != null)
			{
				query = include(query);
			}

			var findEntity = await query.FirstOrDefaultAsync(e => e.Id.Equals(id)).ConfigureAwait(false);
			if (findEntity == null)
			{
				throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Entity with id: {id} not found when trying to update entity. Entity was no Deleted.");
			}

			Delete(findEntity);
		}

		public void Delete(TEntity entityToDelete)
		{
			if (Context.Entry(entityToDelete).State == EntityState.Detached)
			{
				DbSet.Attach(entityToDelete);
			}

			DbSet.Remove(entityToDelete);
		}

		public async Task DeleteManyAsync(Expression<Func<TEntity, bool>> predicate = null,
										  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
		{
			var entitiesToDelete = await GetRangeAsync(count: int.MaxValue, filter: predicate, include: include, disableTracking: false).ConfigureAwait(false);

			DbSet.RemoveRange(entitiesToDelete);
		}

		public Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return DbSet.AsNoTracking().AnyAsync(predicate);
		}

		public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return DbSet.AsNoTracking().CountAsync(predicate);
		}
	}
}
