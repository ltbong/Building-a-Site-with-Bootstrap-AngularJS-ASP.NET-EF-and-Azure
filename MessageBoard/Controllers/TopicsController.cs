using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MessageBoard.Data;

namespace MessageBoard.Controllers
{
    public class TopicsController : ApiController
    {
        private IMessageBoardRepository _repo;

        public TopicsController(IMessageBoardRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Topic> Get()
        {
            var topics = _repo.GetTopics()
                .OrderByDescending(t => t.Created)
                .Take(25)
                .ToList();

            return topics;
        } 
    }
}
