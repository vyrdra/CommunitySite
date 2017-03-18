using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models;
using Microsoft.EntityFrameworkCore;
using CommunitySite.Repository;

namespace CommunitySite.Models.Repository
{
    public class ForumRepository : IForumMessageRepository
    {
        //List<ForumMessage> posts = new List<ForumMessage>();

        private ApplicationDbContext context;
        
        public ForumRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        //public IEnumerable<ForumMessage> Posts => context.ForumMessages;

        //get all posts
        public IQueryable<ForumMessage> GetAllForumMessages()
        {
            return context.ForumMessages.Include(p => p.User).Include(p => p.Replys);
            
        }

        
        //not sure what this is supposed to do
        public List<ForumMessage> GetPostsbyMember(ParkMember user)
        {

            return (from p in context.ForumMessages
                    where p.User.Equals(user)
                    select p).ToList();

        }
        public ParkMember GetMemberByID(int id)
        {
            return context.ParkMembers.First(a => a.ParkMemberID == id);
        }

        //get all posts of that subject
        public List<ForumMessage> GetPostsBySubject(string subject)
        {
            return (from p in context.ForumMessages
                    where p.Subject.Contains(subject)
                    select p).ToList();
        }

        public int Update(ForumMessage post)
        {
            if (post.ForumMessageID == 0)
                context.ForumMessages.Add(post);
            else
                context.ForumMessages.Update(post);

            return context.SaveChanges();
        }

        


    }
}
