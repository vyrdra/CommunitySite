using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommunitySite.Models.ViewModels
{
    public class ReplyViewModel
    {
        
        public int? ReplyID { get; set; }
        [Required(ErrorMessage = "Please enter a reply.")]
        public Reply Reply { get; set; }
    }
}
