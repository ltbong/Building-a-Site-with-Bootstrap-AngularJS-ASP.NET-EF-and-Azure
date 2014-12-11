using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBoard.Data;

namespace MessageBoard.Tests.Fakes
{
    class FakeMessageBoardRepository : IMessageBoardRepository
    {
        public IQueryable<Topic> GetTopics()
        {
            return new Topic[]
                {
                new Topic()
                {
                    Id = 1,
                    Title = "This is a title",
                    Body = "This is a body",
                    Created = DateTime.UtcNow
                },
                new Topic()
                {
                    Id = 2,
                    Title = "This is another title",
                    Body = "This is a body",
                    Created = DateTime.UtcNow
                },
                new Topic()
                {
                    Id = 3,
                    Title = "This is yet another title",
                    Body = "This is a body",
                    Created = DateTime.UtcNow
                },
                }.AsQueryable();
        }

        public IQueryable<Topic> GetTopicsIncludingReplies()
        {
            return new Topic[]
      {
        new Topic()
        {
          Id = 1,
          Title = "This is a title",
          Body = "This is a body",
          Created = DateTime.UtcNow,
          Replies = new Reply[]
          {
            new Reply()
            {
              Id = 1,
              TopicId = 1,
              Body = "Fake Body", 
              Created = DateTime.UtcNow
            },
            new Reply()
            {
              Id = 2,
              TopicId = 1,
              Body = "Another Fake Body", 
              Created = DateTime.UtcNow
            },
            new Reply()
            {
              Id = 3,
              TopicId = 1,
              Body = "Yet Another Fake Body", 
              Created = DateTime.UtcNow
            },
          }
        },
        new Topic()
        {
          Id = 2,
          Title = "This is another title",
          Body = "This is a body",
          Created = DateTime.UtcNow,
          Replies = new List<Reply>()
        },
        new Topic()
        {
          Id = 3,
          Title = "This is yet another title",
          Body = "This is a body",
          Created = DateTime.UtcNow,
          Replies = new List<Reply>()
        },
      }.AsQueryable();
        }

        public IQueryable<Reply> GetRepliesByTopic(int topicId)
        {
            return new Reply[]
              {
                new Reply()
                {
                  Id = 1,
                  TopicId = topicId,
                  Body = "Fake Body", 
                  Created = DateTime.UtcNow
                },
                new Reply()
                {
                  Id = 2,
                  TopicId = topicId,
                  Body = "Another Fake Body", 
                  Created = DateTime.UtcNow
                },
                new Reply()
                {
                  Id = 3,
                  TopicId = topicId,
                  Body = "Yet Another Fake Body", 
                  Created = DateTime.UtcNow
                },
              }.AsQueryable();
        }

        public bool Save()
        {
            return true;
        }

        public bool AddTopic(Topic newTopic)
        {
            newTopic.Id = new Random().Next(5, 1000);
            newTopic.Created = DateTime.UtcNow;
            return true;
        }

        public bool AddReply(Reply newReply)
        {
            newReply.Id = new Random().Next(5, 1000);
            newReply.Created = DateTime.UtcNow;
            return true;
        }
    }
}
