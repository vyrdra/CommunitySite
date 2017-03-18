using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunitySite.Models
{
    public class News
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Story { get; set; }

        public string Author { get; set; }

    }
}
