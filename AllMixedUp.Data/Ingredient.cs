using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Data
{
    public class Ingredient
    {
        [Key]
        public int IngredientID { get; set; }
        [Required]
        public int MaterialID { get; set; }
        [Required]
        public int GlazeID { get; set; }
        [Required]
        public double Quantity { get; set; }
    }
}
