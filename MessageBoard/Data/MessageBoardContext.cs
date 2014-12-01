using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace MessageBoard.Data
{
    public class MessageBoardContext : DbContext
    {
        public MessageBoardContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;      // Anytime you need to serialize objs, lazy loading can cause problems of circular dependencies.
            this.Configuration.ProxyCreationEnabled = false;    // Proxy generation can cause problems in serialization, adding extraneous properties.
            
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<MessageBoardContext, MessageBoardMigrationsConfiguration>()
                ); // Takes care of migrating database to new structure.
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }
    }
}