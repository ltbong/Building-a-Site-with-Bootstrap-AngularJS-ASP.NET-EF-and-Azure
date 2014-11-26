using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageBoard.Data
{
    public class Reply
    {
        public int Id { get; set; } // EF automagically makes this an identity field.
        public string Body { get; set; }
        public DateTime Created { get; set; }

        public int TopicId { get; set; } // EF automagically creates a relationship with Topic.Id
    }
}
