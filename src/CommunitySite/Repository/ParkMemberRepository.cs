using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models;
using Microsoft.EntityFrameworkCore;
using CommunitySite.Repository;

namespace CommunitySite.Models.Repository
{
    public class ParkMemberRepository : IParkMemberRepository
    {

        private ApplicationDbContext context;

        public ParkMemberRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<ParkMember> Members => context.ParkMembers;


        //get one members posts
        public ParkMember GetMemberByName(string alias)
        {

            return context.ParkMembers.First(a => a.ForumAlias == alias);
        }

        //a list of all park members forum names
        public IEnumerable<ParkMember> GetAllParkMembers()
        {
            return context.ParkMembers.Include(p => p.ForumAlias);
        }


    }
}
