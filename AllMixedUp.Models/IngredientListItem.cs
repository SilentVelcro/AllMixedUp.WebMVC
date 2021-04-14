using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Models
{
    public class IngredientListItem
    {
        [Display(Name = "ID")]
        public int IngredientID { get; set; }
        public int MaterialID { get; set; }

        [Display(Name = "Quantity")]
        public double Quantity { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
