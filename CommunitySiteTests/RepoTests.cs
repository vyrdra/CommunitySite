using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models;
using CommunitySite.Controllers;
using Xunit;

namespace CommunitySiteTests
{
    public class RepoTests
    {

        FakeForumRepo fRepo;
        //FakeMemberRepo mRepo;

        ForumController fController;
        List<ForumMessage> postsFromForum;
        
        

        //[Fact]
        //public void CanChangeForumAlias()
        //{
        //    ForumMessage p = new ForumMessage { Subject = "Bags", Date = new DateTime(2 / 2 / 2017), Body = "If you have extra's drop them off." };

        //    p.ForumAlias = "kaja";

        //    Assert.Equal("kaja", p.ForumAlias);
        //}

        //[Fact]
        //public void CanAddForumAlias()
        //{
        //    ForumMessage p = new ForumMessage { Subject = "Bags", Date = new DateTime(2 / 2 / 2017), Body = "If you have extra's drop them off." };

        //    p.ForumAlias = "kaja";

        //    Assert.Equal("kaja", p.ForumAlias);
        //}

        [Fact]
        public void CanChangeForumBody()
        {
            ForumMessage p = new ForumMessage { Subject = "Bags", Date = new DateTime(2 / 2 / 2017), Body = "If you have extra's drop them off." };

            string body = "wow there where alot of squirels today!";
            p.Body = body;

            Assert.Equal(body, p.Body);
        }

    }
}
