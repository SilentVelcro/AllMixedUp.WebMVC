using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Models
{
    public class MaterialEdit
    {
        [Display(Name = "ID")]
        public int MaterialID { get; set; }

        public Guid PotterID { get; set; }

        [Display(Name = "Material Name")]
        public string MaterialName { get; set; }

        [Display(Name = "Health Hazard")]
        public bool HealthHazard { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedDate { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
