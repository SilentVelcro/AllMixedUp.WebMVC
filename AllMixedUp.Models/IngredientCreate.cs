using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Models
{
    public class IngredientCreate
    {
        public Guid OwnerId { get; set; }
        [Display(Name = "ID")]
        public int IngredientID { get; set; }
        public int GlazeID { get; set; }
        public List<string> IngredientList { get; set; }
        public int MaterialID { get; set; }

        [Display(Name = "Material Name")]
        public string MaterialName { get; set; }

        [Display(Name = "Quantity")]
        public double Quantity { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedDate { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}