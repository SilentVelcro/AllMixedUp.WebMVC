using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Data
{
    //Enum(s)
    public enum Atmosphere
    {
        Reduction = 1,
        Oxidation = 2,
        Wood = 3,
        Pit = 4,
        SaltSoda = 5,
        Raku = 6,
    }
    public enum MainColor
    {
        Green = 1,
        Blue = 2,
        Purple = 3,
        Red = 4,
        Orange = 5,
        Yellow = 6,
        White = 7,
        Black = 8,
    }
    public enum MinCone
    {
        Cone022 = 1,
        Cone021 = 2,
        Cone020 = 3,
        Cone019 = 4,
        Cone018 = 5,
        Cone017 = 6,
        Cone016 = 7,
        Cone015 = 8,
        Cone014 = 9,
        Cone013 = 10,
        Cone012 = 11,
        Cone011 = 12,
        Cone010 = 13,
        Cone09 = 14,
        Cone08 = 15,
        Cone07 = 16,
        Cone06 = 17,
        Cone05 = 18,
        Cone04 = 19,
        Cone03 = 20,
        Cone02 = 21,
        Cone01 = 22,
        Cone1 = 23,
        Cone2 = 24,
        Cone3 = 25,
        Cone3Point5 = 26,
        Cone4 = 27,
        Cone5 = 28,
        Cone6 = 29,
        Cone7 = 30,
        Cone8 = 31,
        Cone9 = 32,
        Cone10 = 33,
        Cone11 = 34,
        Cone12 = 35,
        Cone13 = 36,
    }
    public enum MaxCone
    {
        Cone022 = 1,
        Cone021 = 2,
        Cone020 = 3,
        Cone019 = 4,
        Cone018 = 5,
        Cone017 = 6,
        Cone016 = 7,
        Cone015 = 8,
        Cone014 = 9,
        Cone013 = 10,
        Cone012 = 11,
        Cone011 = 12,
        Cone010 = 13,
        Cone09 = 14,
        Cone08 = 15,
        Cone07 = 16,
        Cone06 = 17,
        Cone05 = 18,
        Cone04 = 19,
        Cone03 = 20,
        Cone02 = 21,
        Cone01 = 22,
        Cone1 = 23,
        Cone2 = 24,
        Cone3 = 25,
        Cone3Point5 = 26,
        Cone4 = 27,
        Cone5 = 28,
        Cone6 = 29,
        Cone7 = 30,
        Cone8 = 31,
        Cone9 = 32,
        Cone10 = 33,
        Cone11 = 34,
        Cone12 = 35,
        Cone13 = 36,
    }
    public enum Surface
    {
        Opaque = 1,
        SemiOpaque = 2,
        SemiTransparent = 3,
        Transparent = 4,
        Clear = 5
    }
    public enum Opacity
    {
        DeadMatte = 1,
        Matte = 2,
        Satin = 3,
        SemiGloss = 4,
        Gloss = 5,
    }
    public class Glaze
    {
        [Key]
        public int GlazeID { get; set; }

        public Guid OwnerId { get; set; }

        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [Required]
        public string GlazeName { get; set; }

        public string Description { get; set; }

        //Ingredient
        public virtual ICollection<Ingredient> IngredientList { get; set; }
        public Glaze()
        {
            IngredientList = new HashSet<Ingredient>();
        }

       [Required]
        public bool FoodSafe { get; set; }
        public Atmosphere Atmosphere { get; set; }
        public MainColor MainColor { get; set; }
        public MinCone MinCone { get; set; }
        public MaxCone MaxCone { get; set; }
        public Surface Surface { get; set; }
        public Opacity Opacity { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }

        //public ICollection<Message> Messages { get;}
    }
}
