using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace QQQ.Model
{
    public class Question
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name="Question")]
        public string Title { get; set; }

        [AllowHtml]
        public string Answer { get; set; }
        [Display(Name="Where Did You Find")]
        public string Source { get; set; }
        public int Ratting { get; set; }

       
        public int LevelId { get; set; }

        public virtual Level Level { get; set; }

       
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
