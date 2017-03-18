using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CommunitySite.Models
{
    public class ForumMessage
    {
        public int ForumMessageID { get; set; }
        
        [Required(ErrorMessage = "Please enter a subject.")]
        [StringLength(20, MinimumLength = 3)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter a post body.")]
        public string Body { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        
        public ParkMember User { get; set; }

        private List<Reply> replys = new List<Reply>();
        public List<Reply> Replys { get { return replys; } }

        //private List<ParkMember> members = new List<ParkMember>();
        //public List<ParkMember> ParkMembers { get { return members; } }

        
    }
}
