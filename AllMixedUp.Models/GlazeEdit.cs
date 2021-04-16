using AllMixedUp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AllMixedUp.Data.Glaze;

namespace AllMixedUp.Models
{
    public class GlazeEdit
    {
        [Display(Name = "ID")]
        public int GlazeID { get; set; }

        [Display(Name = "Glaze")]
        public string GlazeName { get; set; }

        [Display(Name = "UserID")]
        public int UserID { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Ingredient(s)")]
        public List<Ingredient> IngredientList { get; set; }

        [Display(Name = "Atmosphere")]
        public FireProcess Atmosphere { get; set; }

        [Display(Name = "Minimum Cone")]
        public MinCone MinimumCone { get; set; }

        [Display(Name = "Maximum Cone")]
        public MaxCone MaximumCone { get; set; }

        [Display(Name = "Color")]
        public MainColor Hue { get; set; }

        //public List<string> Ingredients { get; set; }

        [Display(Name = "Food safe")]
        public bool FoodSafe { get; set; }

        [Display(Name = "Finish")]
        public int FinishID { get; set; }

        public virtual Finish Finish { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedDate { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
