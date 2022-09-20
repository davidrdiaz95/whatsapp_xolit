using Microsoft.EntityFrameworkCore;
using Xolit.Whatsapp.DataAccess.Configurations;
using Xolit.Whatsapp.DataAccess.Models;

namespace Xolit.Whatsapp.DataAccess.Context
{
    public class WhatsaapContex : DbContext
    {
        public DbSet<Conversation> Conversation { get; set; }
        public DbSet<MessageConversation> MessageConversation { get; set; }

        public WhatsaapContex(DbContextOptions options) : base(options)
        {
        }

        public WhatsaapContex()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Property Configurations
            modelBuilder.ApplyConfiguration(new ConversationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConversationEntityConfiguration());
        }
    }
}
