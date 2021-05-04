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
        public int MaterialID { get; set; }
        public int GlazeID { get; set; }

        public List<int> IngredientList { get; set; }

        [Display(Name = "Material Name")]
        public string MaterialName { get; set; }

        [Display(Name = "Quantity")]
        public double Quantity { get; set; }
    }
}
