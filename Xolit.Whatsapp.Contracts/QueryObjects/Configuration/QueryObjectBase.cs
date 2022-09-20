using System.Collections.Generic;
using System.Linq;
using Xolit.Whatsapp.Contracts.QueryObjects.Configuration.Imp;

namespace Xolit.Whatsapp.Contracts.QueryObjects.Configuration
{
    public abstract class QueryObjectBase<T> : IQueryObjectBase<T>
    {
        protected abstract IQueryable<T> AppliFylters(IQueryable<T> query);

        protected abstract void Clear();

        protected abstract IQueryable<T> NewQueryInstance();

        private IQueryable<T> GenerateQueryExpression()
        {
            var query = this.NewQueryInstance();

            query = this.AppliFylters(query);

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
