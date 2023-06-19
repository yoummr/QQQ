using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QQQ.Mvc5WebUI.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Lavel { get; set; }
        public string Category { get; set; }
        public int Ratting { get; set; }
    }
}