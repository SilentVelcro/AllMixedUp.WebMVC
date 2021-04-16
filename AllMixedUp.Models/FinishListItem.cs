using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AllMixedUp.Data.Finish;

namespace AllMixedUp.Models
{
    public class FinishListItem
    {
        [Display(Name = "ID")]
        public int FinishID { get; set; }

        [Display(Name = "Opacity")]
        public Opacity Op { get; set; }

        [Display(Name = "Surface")]
        public Surface Surf { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedDate { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
