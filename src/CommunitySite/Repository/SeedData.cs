using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using CommunitySite.Models;
using Microsoft.AspNetCore.Identity;

namespace CommunitySite.Repository
{
    public class SeedData
    {
        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext ident = app.ApplicationServices
                .GetRequiredService<AppIdentityDbContext>();
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();

            //testing hard coded user
            string firstName = "Ash Cole";
            string lastName = "Plute";
            string dogName = "DOG";
            string dogBreed = "Mal";
            string forumAl = "Rhasedi";
            string userName = "test";
            string email = "test@test.com";
            string password = "guest";

            //using park member becuase it now uses the Identity class, usermanager basiclly stores the user in session
            UserManager<ParkMember> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<ParkMember>>();

            if (!context.ForumMessages.Any())
            {
                ParkMember user = await userManager.FindByNameAsync(userName);
                if (user == null)
                {
                    user = new ParkMember
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            DogName = dogName,
                            DogBreed = dogBreed,
                            ForumAlias = forumAl,
                            UserName = userName,
                            Email = email
                        };
                  
                    IdentityResult result = await userManager.CreateAsync(user, password);
                }


                ParkMember pm = new ParkMember { FirstName = "Aaron", LastName = "Plute", Email = "otterstetterai@hotmail.com", DogName = "Ash Cole PLute", DogBreed = "Malinous Mix", ForumAlias="Rha" };
                    context.ParkMembers.Add(pm);
                ForumMessage post = new ForumMessage { Subject = "Thief", Body = "Dont let your dog steal balls for extended periods!", Date = new DateTime(2017, 1, 12) };
                post.User = pm;
                    context.ForumMessages.Add(post);


                post = new ForumMessage { Subject = "Birthday", Body = "Ash is having a birthday party", Date = new DateTime(2017, 7, 25) };
                post.User = pm;
                context.ForumMessages.Add(post);
                post = new ForumMessage { Subject = "Walkers", Body = " Need a good dog walker! ", Date = new DateTime(2017, 1, 15) };
                post.User = pm;
                context.ForumMessages.Add(post);

                pm = new ParkMember { FirstName = "Jene", LastName = "Hubbard", Email = "jhub@gmail.com", DogName = "Webster", DogBreed = "Hound", ForumAlias = "Ka" };
                context.ParkMembers.Add(pm);
                post = new ForumMessage { Subject = "Birthday", Body = "Webster is having a birthday party", Date = new DateTime(2017, 1, 4) };
                post.User = pm;
                context.ForumMessages.Add(post);

                pm = new ParkMember { FirstName = "Dustin", LastName = "Smith", Email = "dsmith@gmail.com", DogName = "Odin", DogBreed = "Shepard Mix", ForumAlias = "Nut" };
                context.ParkMembers.Add(pm);
                post = new ForumMessage { Subject = "Walkers", Body = "Does anyone have a good dog walker for dominant dogs?", Date = new DateTime(2016, 12, 3) };
                post.User = pm;
                context.ForumMessages.Add(post);
                post = new ForumMessage { Subject = "Thief", Body = "Ok the theiving has gotten bad", Date = new DateTime(2017, 1, 12) };
                post.User = pm;
                context.ForumMessages.Add(post);


                context.SaveChanges();
            }
        }
    }
}
