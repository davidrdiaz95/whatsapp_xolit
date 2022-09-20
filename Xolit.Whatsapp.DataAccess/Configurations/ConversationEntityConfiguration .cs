using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xolit.Whatsapp.DataAccess.Models;

namespace Xolit.Whatsapp.DataAccess.Configurations
{
    internal class ConversationEntityConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.ToTable("Conversation");
            builder.HasKey(x=> x.IdConversation);
            builder.HasMany(x => x.MessageConversation).WithOne(x => x.Conversation);
        }
    }
}
