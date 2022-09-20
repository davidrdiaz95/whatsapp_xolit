using System.Linq;
using Xolit.Whatsapp.Contracts.QueryObjects.Configuration;
using Xolit.Whatsapp.Contracts.QueryObjects.MessageConversation;
using Xolit.Whatsapp.DataAccess.Context;

namespace Xolit.Whatsapp.Domain.QueryObjects.MessageConversation
{
    public class MessageConversationQueryObject : QueryObjectBase<DataAccess.Models.MessageConversation>, IMessageConversationQueryObject
    {
        private readonly WhatsaapContex context;
        public int? Id;

        public MessageConversationQueryObject(WhatsaapContex whatsaapContex)
        {
            this.context = whatsaapContex;
        }

        public IMessageConversationQueryObject ForId(int id)
        {
            this.Id = Id;
            return this;
        }

        protected override IQueryable<DataAccess.Models.MessageConversation> AppliFylters(IQueryable<DataAccess.Models.MessageConversation> query)
        {
            if (this.Id != null)
                query = query.Where(x => x.IdMessageConversation.Equals(this.Id));
            return query;
        }

        protected override void Clear()
        {
            this.Id = null;
        }

        protected override IQueryable<DataAccess.Models.MessageConversation> NewQueryInstance()
        {
            return this.context.MessageConversation.AsQueryable();
        }
    }
}
