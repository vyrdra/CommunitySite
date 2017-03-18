using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models.Repository;

namespace CommunitySite.Models
{
    public interface IForumMessageRepository
    {
        IQueryable<ForumMessage> GetAllForumMessages();

         List<ForumMessage> GetPostsbyMember(ParkMember user);

         ParkMember GetMemberByID(int id);
         int Update(ForumMessage newPost);
    }
}
