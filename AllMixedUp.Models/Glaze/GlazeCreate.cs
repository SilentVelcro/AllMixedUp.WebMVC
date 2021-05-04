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
    public class GlazeCreate
    {
        public Guid OwnerId { get; set; }

        [Display(Name = "ID")]
        public int GlazeID { get; set; }

        [Required]
        [Display(Name = "Glaze Name")]
        public string GlazeName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        //[Required]
        [Display(Name = "Ingredient(s)")]
        public List<IngredientDetail> IngredientList { get; set; }

        [Required]
        [Display(Name = "Food safe")]
        public bool FoodSafe { get; set; }

        [Required]
        [Display(Name = "Atmosphere")]
        public Atmosphere Atmosphere { get; set; }

        [Required]
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

        [Display(Name = "Created")]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
