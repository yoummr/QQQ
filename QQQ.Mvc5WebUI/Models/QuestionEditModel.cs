using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QQQ.Model;

namespace QQQ.Mvc5WebUI.Models
{
    public class QuestionEditModel
    {
        public string Title { get; set; }
        public string Answer { get; set; }
        public string Source { get; set; }
        public int Rating { get; set; }

        public ICollection<Level>   Levels { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}