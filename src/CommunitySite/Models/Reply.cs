using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CommunitySite.Models
{
    public class Reply
    {
        
        public int? ReplyID { get; set; }
        
        public string Body { get; set; }

        public string From { get; set; }
    }
}
