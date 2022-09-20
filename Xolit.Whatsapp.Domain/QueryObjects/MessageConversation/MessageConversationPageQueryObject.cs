using System;
using System.Linq;
using Xolit.Whatsapp.Contracts.QueryObjects.Configuration;
using Xolit.Whatsapp.Contracts.QueryObjects.Configuration.Imp;
using Xolit.Whatsapp.Contracts.QueryObjects.MessageConversation;
using Xolit.Whatsapp.DataAccess.Context;
using Xolit.Whatsapp.DataTransferObjects.QueryObjects;

namespace Xolit.Whatsapp.Domain.QueryObjects.MessageConversation
{
    public class MessageConversationPageQueryObject : QueryObjectPageBase<DataAccess.Models.MessageConversation>, IMessageConversationPageQueryObject
    {
        private readonly WhatsaapContex context;
        public int? Id;
        public DateTime? Date;
        public MessageConversationSortType? SortByValue;
        public bool SortByDesc = false;
        public MessageConversationSortType? ThenBy;
        public bool SortThenByDesc = false;

        public MessageConversationPageQueryObject(WhatsaapContex context)
        {
            this.context = context;
        }

        protected override int Page { get; set; }

        protected override int Size { get; set; }

        public IMessageConversationPageQueryObject ForId(int id)
        {
            this.Id = Id;
            return this;
        }

        public IQueryObjectBase<DataAccess.Models.MessageConversation> SetPagination(int page, int size)
        {
            this.Page = page;
            this.Size = size;
            return this;
        }

        public IMessageConversationPageQueryObject SortBy(MessageConversationSortType contactSortType, bool desc)
        {
            this.SortByValue = contactSortType;
            this.SortByDesc = desc;
            return this;
        }

        public IMessageConversationPageQueryObject ThenSortBy(MessageConversationSortType contactSortType, bool desc)
        {
            this.ThenBy = contactSortType;
            this.SortThenByDesc = desc;
            return this;
        }

        protected override IQueryable<DataAccess.Models.MessageConversation> AppliFylters(IQueryable<DataAccess.Models.MessageConversation> query)
        {
            if(this.Id != null)
                query = query.Where(x => x.IdMessageConversation.Equals(this.Id));
            return query;
        }

        protected override IOrderedQueryable<DataAccess.Models.MessageConversation> ApplySort(IQueryable<DataAccess.Models.MessageConversation> query)
        {
            IOrderedQueryable<DataAccess.Models.MessageConversation> order = null;
            switch (this.SortByValue.Value)
            {
                case MessageConversationSortType.IdMessageConversation:
                    order = this.SortByDesc ? query.OrderByDescending(x => x.IdMessageConversation) : query.OrderBy(x => x.IdMessageConversation);
                    break;
            }

            return order;
        }

        protected override IOrderedQueryable<DataAccess.Models.MessageConversation> ApplyThenSort(IOrderedQueryable<DataAccess.Models.MessageConversation> query)
        {
            if (this.ThenBy.HasValue)
            {
                switch (this.ThenBy.Value)
                {
                    case MessageConversationSortType.IdMessageConversation:
                        query = this.SortThenByDesc ? query.ThenByDescending(x => x.IdMessageConversation) : query.ThenBy(x => x.IdMessageConversation);
                        break;
                }
            }

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
