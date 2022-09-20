using System.Collections.Generic;
using System.Linq;
using Xolit.Whatsapp.Contracts.QueryObjects.Configuration.Imp;

namespace Xolit.Whatsapp.Contracts.QueryObjects.Configuration
{
    public abstract class QueryObjectPageBase<T> : IQueryObjectBase<T>
    {
        protected abstract int Page { get; set; }

        protected abstract int Size { get; set; }

        protected abstract IQueryable<T> AppliFylters(IQueryable<T> query);

        protected abstract IQueryable<T> NewQueryInstance();

        protected abstract IOrderedQueryable<T> ApplySort(IQueryable<T> query);

        protected abstract IOrderedQueryable<T> ApplyThenSort(IOrderedQueryable<T> query);

        protected abstract void Clear();

        private IQueryable<T> GenerateQueryExpression()
        {
            var query = this.NewQueryInstance();

            query = this.AppliFylters(query);

            query = this.ApplyPagination(this.ApplyThenSort(this.ApplySort(query)));

            return query;
        }

        private IQueryable<T> ApplyPagination(IOrderedQueryable<T> queryOrder)
        {
            return queryOrder.Skip(Page * Size).Take(Size);
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
