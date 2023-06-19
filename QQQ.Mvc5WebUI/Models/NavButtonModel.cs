using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QQQ.Model;

namespace QQQ.Mvc5WebUI.Models
{
    public class NavButtonModel
    {
        public List<Category> Categories { get; set; }
        public List<Level> Levels { get; set; }
    }
}