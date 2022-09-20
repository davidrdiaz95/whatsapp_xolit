using Xolit.Whatsapp.Contracts.QueryObjects.Configuration.Imp;
using Xolit.Whatsapp.DataTransferObjects.QueryObjects;

namespace Xolit.Whatsapp.Contracts.QueryObjects.MessageConversation
{
    public interface IMessageConversationPageQueryObject : IQueryObjectBase<DataAccess.Models.MessageConversation>, IQueryObjectPageBase<DataAccess.Models.MessageConversation>
    {
        IMessageConversationPageQueryObject ForId(int id);
        IMessageConversationPageQueryObject SortBy(MessageConversationSortType contactSortType, bool desc);

        IMessageConversationPageQueryObject ThenSortBy(MessageConversationSortType contactSortType, bool desc);
    }
}
