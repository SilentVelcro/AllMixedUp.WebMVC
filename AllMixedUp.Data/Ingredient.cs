using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Data
{
    public class Ingredient
    {
        [Key]
        public int IngredientID { get; set; }

        public Guid OwnerId { get; set; }

        [ForeignKey("Material")]
        public int MaterialID { get; set; }
        public virtual Material Material { get; set; }

        [ForeignKey("Glaze")]
        public int GlazeID { get; set; }
        public virtual Glaze Glaze { get; set; }

        [Required]
        public double Quantity { get; set; }

        public virtual ICollection<Material> MaterialList { get; set; }
        public Ingredient()
        {
            MaterialList = new HashSet<Material>();
        }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
