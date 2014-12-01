using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace MessageBoard.Data
{
    public class MessageBoardMigrationsConfiguration : DbMigrationsConfiguration<MessageBoardContext>
    {
        public MessageBoardMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true; // might want to disable in prod with #ifdebug... This is dangerous!
            this.AutomaticMigrationsEnabled = true; // Migrates data from old to new version of db.
        }

        protected override void Seed(MessageBoardContext context)
        {
            // As of EF 4.3, Seed is called every time a new app domain is created, or app starts up.
            // So, you need to be careful where it is called.
            base.Seed(context);

#if DEBUG
            if (context.Topics.Count() == 0)
            {
                var topic = new Topic()
                {
                    Title = "I love MVC",
                    Created = DateTime.Now,
                    Body = "I love ASP.NET MVC and I want everyone to know it!",
                    Replies = new List<Reply>()
                    {
                        new Reply()
                        {
                            Body = "I too love it!",
                            Created = DateTime.Now
                        },
                        new Reply()
                        {
                            Body = "Me too!",
                            Created = DateTime.Now
                        },
                        new Reply()
                        {
                            Body = "Aw shucks!",
                            Created = DateTime.Now
                        }
                    }
                };

                context.Topics.Add(topic);

                var anotherTopic = new Topic()
                {
                    Title = "I like Ruby too!",
                    Created = DateTime.Now,
                    Body = "Ruby on Rails is popular."
                };

                context.Topics.Add(anotherTopic);

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            }
#endif
        }
    }
}
