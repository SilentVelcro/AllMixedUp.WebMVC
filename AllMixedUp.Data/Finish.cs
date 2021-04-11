using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Data
{
    public class Finish
    {
        [Key]
        public int FinishID { get; set; }
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
    }
}
