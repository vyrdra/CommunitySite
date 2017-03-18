using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunitySite.Models.Repository;

namespace CommunitySite.Models
{
    public interface IParkMemberRepository
    {
        IEnumerable<ParkMember> GetAllParkMembers();
        ParkMember GetMemberByName(string name);

    }
}
