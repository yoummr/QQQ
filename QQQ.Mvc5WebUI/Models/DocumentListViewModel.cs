using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QQQ.Mvc5WebUI.Models
{
    public class DocumentListViewModel
    {
        public int Id { get; set; }
        [Display(Name="No")]
        public int Count { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Contents { get; set; }
        [Display(Name="Desc")]
        public string Description { get; set; }

        [Display(Name="Date")]
        public DateTime CreateDate { get; set; }

        public int Priority { get; set; }
    }
}