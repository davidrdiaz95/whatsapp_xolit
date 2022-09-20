namespace Xolit.Whatsapp.Contracts.Mappers
{
    public interface IMapper
    {
        public interface IMapper<P, T>
        {
            P MapTo(T model);
            T MapFrom(P model);
        }
    }
}
