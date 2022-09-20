using System.Collections.Generic;

namespace Xolit.Whatsapp.Contracts.QueryObjects.Configuration.Imp
{
    public interface IQueryObjectBase<T>
    {
        IEnumerable<T> Query();

        T QueryFirst();
    }
}
