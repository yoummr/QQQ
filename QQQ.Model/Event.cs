using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QQQ.Model
{
    public class Event
    {
        public Event()
        {
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public String Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
