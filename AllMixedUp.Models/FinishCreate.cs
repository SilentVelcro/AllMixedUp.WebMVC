using AllMixedUp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AllMixedUp.Data.Finish;

namespace AllMixedUp.Models
{
    public class FinishCreate
    {
        [Display(Name = "ID")]
        public int FinishID { get; set; }

        [Display(Name = "Opacity")]
        public Opacity Opacity { get; set; }

        [Display(Name = "Surface")]
        public Surface Surface { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
