using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace CommunitySite.Models
{
    public class ParkMember : IdentityUser
    {
        public int ParkMemberID { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Please enter a email")]
        //[EmailAddress]
        //public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your dog's name")]
        public string DogName { get; set; }

        public string DogBreed { get; set; }

        [Required(ErrorMessage = "Please enter a forum name")]
        public string ForumAlias { get; set; }

        //[Required(ErrorMessage = "Please enter a user name")]
        //public string UserName { get; set; }

        [Required]
        public string Password { get; set; }



        public override bool Equals(object obj)
        {
            ParkMember memObj = obj as ParkMember;
            if (memObj == null)
                return false;
            else
                return ForumAlias == memObj.ForumAlias;
        }

        public override int GetHashCode()
        {
            return ParkMemberID;
        }

    }
}
