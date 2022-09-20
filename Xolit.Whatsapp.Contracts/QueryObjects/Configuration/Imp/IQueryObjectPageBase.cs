namespace Xolit.Whatsapp.Contracts.QueryObjects.Configuration.Imp
{
    public interface IQueryObjectPageBase<T>
    {
        IQueryObjectBase<T> SetPagination(int page, int size);
    }
}
