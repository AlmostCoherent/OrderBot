
using OrderBot.Entity.Models;
using OrderBot.Entity.Models.Support;
using System;
using System.Data.Entity;

namespace OrderBot.Entity
{
    public class OrderBotContext : DbContext
    {
        public OrderBotContext() : base("name=OrderBot")
        {
        }
        public DbSet<SupportRequest> SupportRecords { get; set; }
        public DbSet<SupportRequestMessage> SupportMessages { get; set; }
    }
}
