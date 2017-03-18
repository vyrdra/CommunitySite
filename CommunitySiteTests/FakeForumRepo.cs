using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models;

namespace CommunitySiteTests
{
    public class FakeForumRepo 
    {
        public IEnumerable<ForumMessage> ForumMessages => new List<ForumMessage>
        {
            new ForumMessage {ForumMessageID = 1,  Subject = "Ball thiefs", Body = "Dont let your dog steal balls for extended periods!", Date = new DateTime(2017, 1, 12)},
            new ForumMessage {ForumMessageID = 2,  Subject = "Birthday Party", Body = "Webster is having a birthday party", Date = new DateTime(2017, 1, 4)},
            new ForumMessage {ForumMessageID = 3,  Subject = "Dog walkers?", Body = "Does anyone have a good daog walker for dominant dogs?", Date = new DateTime(2016, 12, 3)},

        };
    }
}
