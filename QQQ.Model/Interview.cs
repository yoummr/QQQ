using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace QQQ.Model
{
    public class Interview
    {
        public Interview()
        {
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }

        public string ClientName { get; set; }
        public string InterViewerName { get; set; }

        public string DateAndTime { get; set; }
        public string phone { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        [AllowHtml]
        public string Tropics { get; set; }

        public DateTime CreateDate { get; set; }

        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }


    }
}
