using CommunitySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunitySiteTests
{
    public class FakeMemberRepo
    {
        public class FakeParkMemRepo : IParkMemberRepository
        {
            public List<ParkMember> GetAllParkMembers
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public IEnumerable<ParkMember> ParkMember => new List<ParkMember> {
            new ParkMember {UserID = 1, FirstName ="Aaron", LastName = "Plute", Email = "otterstetterai@hotmail.com", DogName = "Ash Cole PLute", DogBreed = "Malinous Mix"  },
            new ParkMember {UserID = 2, FirstName ="Jene", LastName = "Hubbard", Email = "jhub@gmail.com", DogName = "Webster", DogBreed = "Hound"  },
            new ParkMember {UserID = 3, FirstName ="Dustin", LastName = "Smith", Email = "dsmith@gmail.com", DogName = "Odin", DogBreed = "Shepard Mix"  }
        };

            public IEnumerable<ParkMember> ParkMembers
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public ParkMember GetMemberByName(string name)
            {
                throw new NotImplementedException();
            }
        }
    }
}
