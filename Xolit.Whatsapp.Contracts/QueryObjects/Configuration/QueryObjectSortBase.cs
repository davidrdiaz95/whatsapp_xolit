using System.Collections.Generic;
using System.Linq;
using Xolit.Whatsapp.Contracts.QueryObjects.Configuration.Imp;

namespace Xolit.Whatsapp.Contracts.QueryObjects.Configuration
{
    public abstract class QueryObjectSortBase<T> : IQueryObjectBase<T>
    {
        protected abstract IQueryable<T> AppliFylters(IQueryable<T> query);

        protected abstract IQueryable<T> NewQueryInstance();

        protected abstract IOrderedQueryable<T> ApplySort(IQueryable<T> query);

        protected abstract IOrderedQueryable<T> ApplyThenSort(IOrderedQueryable<T> query);

        protected abstract void Clear();

        private IQueryable<T> GenerateQueryExpression()
        {
            var query = this.NewQueryInstance();

            query = this.AppliFylters(query);

            query = this.ApplyThenSort(this.ApplySort(query)).AsQueryable();

            return query;
        }

        public IEnumerable<T> Query()
        {
            var query = this.GenerateQueryExpression();

            return query.ToList();
        }

        public T QueryFirst()
        {
            var query = this.GenerateQueryExpression();

            return query.FirstOrDefault();
        }
    }
}
