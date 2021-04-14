using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Models
{
    public class FinishListItem
    {
        [Display(Name = "ID")]
        public int FinishID { get; set; }

        [Display(Name = "Opacity")]
        public string Opacity { get; set; }

        [Display(Name = "Surface")]
        public string Surface { get; set; }
    }
}
