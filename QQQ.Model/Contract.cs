using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QQQ.Model
{
    public class Contract
    {
        public int Id { get; set; }

        [Display(Name = "Vendor Name")]
        public string Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Extenstio { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Interview> Interviews { get; set; }

    }
}
