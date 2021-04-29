using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Models
{
    public class MaterialListItem
    {
        [Display(Name = "ID")]
        public int MaterialID { get; set; }

        [Display(Name = "Teacher Name")]
        public string MaterialName { get; set; }

        [Display(Name = "Health Hazard")]
        public bool HealthHazard { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
