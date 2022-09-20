using System.Collections.Generic;
using System.Linq;
using Xolit.Whatsapp.Contracts.QueryObjects.Configuration.Imp;

namespace Xolit.Whatsapp.Contracts.QueryObjects.Configuration.Extensions
{
    public static class QueryObjectExtensions
    {
        public static List<T> GetAll<T>(this IQueryObjectBase<T> query)
        {
            var queryBuilder = query.Query();
            return queryBuilder.ToList();
        }
        public static T GetFirst<T>(this IQueryObjectBase<T> query)
        {
            return query.QueryFirst();
        }
    }
}
