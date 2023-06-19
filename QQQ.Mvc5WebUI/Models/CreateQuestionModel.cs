using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using QQQ.Model;


namespace QQQ.Mvc5WebUI.Models
{
    public class CreateQuestionModel
    {
        public int Id { get; set; }

        [AllowHtml]
        public string Title { get; set; }

        [AllowHtml]
        public string Answer { get; set; }
        public string Source { get; set; }
        public int Ratting { get; set; }

        public int LevelId { get; set; }
        public virtual Level Level { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
