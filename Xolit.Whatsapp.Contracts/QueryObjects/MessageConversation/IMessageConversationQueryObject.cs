using Xolit.Whatsapp.Contracts.QueryObjects.Configuration.Imp;

namespace Xolit.Whatsapp.Contracts.QueryObjects.MessageConversation
{
    public interface IMessageConversationQueryObject : IQueryObjectBase<DataAccess.Models.MessageConversation>
    {
        IMessageConversationQueryObject ForId(int id);
    }
}
