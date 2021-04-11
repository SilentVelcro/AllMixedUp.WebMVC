using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Data
{
    public class Glaze
    {
        [Key]
        public int GlazeID { get; set; }
        public int UserID { get; set; }
        [Required]
        public string GlazeName { get; set; }
        public DateTimeOffset CreatedRecipeDate { get; set; }
        public string Description { get; set; }
        [Required]
        public bool FoodSafe { get; set; }
        [Required]
        public int FinishID { get; set; }
        public enum FireProcess
        {
            Reduction = 1,
            Oxidation = 2,
            Wood = 3,
            Pit = 4,
            SaltSoda = 5,
            Raku = 6,
        }

        //public enum MinCone
        //{

        //}
        //public enum MaxCone
        //{

        //}

        //public enum MainColor
        //{

        //}
    }
}
