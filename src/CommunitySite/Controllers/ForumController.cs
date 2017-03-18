using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CommunitySite.Models;
using CommunitySite.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CommunitySite.Controllers
{
    public class ForumController : Controller
    {
        private IParkMemberRepository memRepo;
        private IForumMessageRepository forumRepo;

        public ForumController(IForumMessageRepository repo, IParkMemberRepository mRepo)
        {
            memRepo = mRepo;
            forumRepo = repo;
        }

        
        public ViewResult Forum()
        {
            return View(forumRepo.GetAllForumMessages().ToList());
        }

        public ViewResult PostsBySubject(string subject)
        {
            ViewBag.Subject = subject;
            return View("Forum", forumRepo.GetAllForumMessages()
                .Where(p => p.Subject == subject).ToList());
        }

        public ViewResult PostByMember(string alias)
        {
            return View("Forum", forumRepo.GetAllForumMessages()
                .Where(m => m.User.ForumAlias == alias).ToList());
        }

        public ViewResult ShowAllMessages()
        {
            return View("Forum", forumRepo.GetAllForumMessages().ToList());
        }

        
        [HttpGet]
        //[Authorize]
        public ViewResult AddPost()
        {
            //ParkMember user = memRepo.GetMemberByName(alias); add after login
            ViewBag.Error = "";
            DateTime now = DateTime.Now;
            string today = now.ToString("MMMM dd, yyyy");
            

            ViewBag.Today = today;
            return View( new ForumMessage());
            
        }

        [HttpPost]
        //[Authorize]
        public ViewResult AddPost(ForumMessage newPost)
        {
            string ai = newPost.User.ForumAlias;
            if (string.IsNullOrEmpty(ai))
            {
                string error = "User.ForumAlias";
                ModelState.AddModelError(error, "Please enter your forum name.");
            }

            if (ModelState.IsValid)
            {
                
                ParkMember from = memRepo.GetMemberByName(ai);
                newPost.User = from;
                forumRepo.Update(newPost);
                //TempData["message"] = $"{from} has posted a new message";
                return View("Forum", forumRepo.GetAllForumMessages().ToList());
            }

            else
                return View();
          
        }

        [HttpGet]
        //[Authorize]
        public ViewResult ReplyForm(int id)
        {
            ReplyViewModel r = new ReplyViewModel();
            r.ReplyID = id;
            r.Reply = new Reply();

            return View(r);
        }

        [HttpPost]
        //[Authorize]
        public IActionResult ReplyForm(ReplyViewModel r)
        {
            if(ModelState.IsValid)
            {
                ForumMessage fm = (from m in forumRepo.GetAllForumMessages()
                                   where m.ForumMessageID == r.ReplyID
                                   select m).FirstOrDefault<ForumMessage>();

                fm.Replys.Add(r.Reply);
                forumRepo.Update(fm);

                return RedirectToAction("Forum", forumRepo.GetAllForumMessages().ToList());
  
            }
            else
            {
                return View(r);
            }
           
        }
       
    }
}
