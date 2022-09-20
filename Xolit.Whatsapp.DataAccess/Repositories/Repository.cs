using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xolit.Whatsapp.DataAccess.Context;
using Xolit.Whatsapp.DataAccess.Repositories.Imp;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Xolit.Whatsapp.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly WhatsaapContex context;
        private DbSet<T> entities;

        public Repository(WhatsaapContex context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            context.SaveChanges();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes)
        {
            var query = entities
                .AsNoTracking()
                .Where(predicate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }


            IEnumerable<T> results = query.ToList();
            return results;
        }
        public T SingleFindBy(Expression<Func<T, bool>> predicate)
        {
            T results = entities
                .SingleOrDefault(predicate);
            return results;
        }

        public T SingleFindByInclude(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes)
        {
            var query = entities
                .AsNoTracking()
                .Where(predicate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }


            T results = query.SingleOrDefault();
            return results;
        }

        public IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes)
        {
            var query = entities
                .AsNoTracking()
                .Where(predicate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            IEnumerable<T> results = query.ToList();
            return results;
        }

        public int CoutFindBy(Expression<Func<T, bool>> predicate)
        {
            int results = entities
                .AsNoTracking()
                .Where(predicate)
                .Count();
            return results;
        }
    }
}
