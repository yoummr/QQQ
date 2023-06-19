using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace QQQ.Model
{
    public class Document
    {
        public Document()
        {
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }

        [AllowHtml]
        public string Contents { get; set; }
        public string Description { get; set; }
       
        public DateTime CreateDate { get; set; }

        public int Priority { get; set; }
    }
}
