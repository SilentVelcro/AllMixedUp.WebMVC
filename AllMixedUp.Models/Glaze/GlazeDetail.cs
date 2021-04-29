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
    public class GlazeDetail
    {
        [Display(Name = "ID")]
        public int GlazeID { get; set; }

        [Display(Name = "Glaze")]
        public string GlazeName { get; set; }

        [Display(Name = "User")]
        public string User { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Ingredient(s)")]
        public ICollection<Ingredient> IngredientList { get; set; }

        [Display(Name = "Atmosphere")]
        public Atmosphere Atmosphere { get; set; }

        [Display(Name = "Minimum Cone")]
        public MinCone MinCone { get; set; }

        [Display(Name = "Maximum Cone")]
        public MaxCone MaxCone { get; set; }

        [Display(Name = "Color")]
        public MainColor MainColor { get; set; }

        [Display(Name = "Surface of Glaze Finish")]
        public Surface Surface { get; set; }

        [Display(Name = "Opacity of Glaze Finish")]
        public Opacity Opacity { get; set; }

        [Display(Name = "Food safe")]
        public bool FoodSafe { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedDate { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
