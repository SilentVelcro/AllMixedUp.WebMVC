using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Models
{
    public class MaterialDetail
    {
        [Display(Name = "ID")]
        public int MaterialID { get; set; }

        [Display(Name = "Material Name")]
        public string MaterialName { get; set; }

        [Display(Name = "Health Hazard")]
        public bool HealthHazard { get; set; }

    }
}
