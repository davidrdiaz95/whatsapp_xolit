using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xolit.Whatsapp.DataAccess.Models;

namespace Xolit.Whatsapp.DataAccess.Configurations
{
    public class MessageConversationEntityConfiguration : IEntityTypeConfiguration<MessageConversation>
    {
        public void Configure(EntityTypeBuilder<MessageConversation> builder)
        {
            builder.ToTable("MessageConversation");
            builder.HasKey(x=> x.IdMessageConversation);
            builder.HasOne(x => x.Conversation).WithMany(x=> x.MessageConversation).HasForeignKey(x=> x.FkIdConversation);
        }
    }
}
