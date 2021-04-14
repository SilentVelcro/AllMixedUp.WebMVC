using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Models
{
    public class GlazeListItem
    {
        [Display(Name = "ID")]
        public int GlazeID { get; set; }

        [Display(Name = "Glaze")]
        public string GlazeName { get; set; }

        [Display(Name = "Food safe")]
        public bool FoodSafe { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
