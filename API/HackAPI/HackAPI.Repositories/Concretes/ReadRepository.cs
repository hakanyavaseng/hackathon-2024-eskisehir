﻿using HackAPI.Entities.Entities.Common;
using HackAPI.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace HackAPI.Repositories.Concretes
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly DbContext context;

        public ReadRepository(DbContext context)
        {
            this.context = context;
        }
        protected DbSet<T> Table => context.Set<T>();

        public IQueryable<T> AsQueryable() => Table.AsQueryable();

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;

            //Check all parameters if there is not null.
            if (!enableTracking)
                queryable = queryable.AsNoTracking(); // Change tracker is not going to track instances anymore.
            if (include is not null)
                queryable = include(queryable); // Include relational tables.
            if (predicate is not null)
                queryable = queryable.Where(predicate); //Where clause.
            if (orderBy is not null)
                return await orderBy(queryable).ToListAsync(); //Order by.

            return await queryable.ToListAsync();
        }

        public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryable = Table;

            //Check all parameters if there is not null.
            if (!enableTracking)
                queryable = queryable.AsNoTracking(); // Change tracker is not going to track instances anymore.
            if (include is not null)
                queryable = include(queryable); // Include relational tables.
            if (predicate is not null)
                queryable = queryable.Where(predicate); //Where clause.
            if (orderBy is not null)
                return await orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync(); //Paging and order by

            return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;

            if (!enableTracking)
                queryable = queryable.AsNoTracking(); // Change tracker is not going to track instances anymore.
            if (include is not null)
                queryable = include(queryable); // Include relational tables.

            return await queryable.FirstOrDefaultAsync(predicate);
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if (predicate is not null)
                Table.Where(predicate);

            return await Table.CountAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
        {
            if (!enableTracking)
                Table.AsNoTracking();

            return Table.Where(predicate);
        }



    }
}
