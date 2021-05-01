﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Data
{
    public class Material
    {
        public Guid OwnerId { get; set; }

        [Key]
        public int MaterialID { get; set; }

        [Required]
        public string MaterialName { get; set; }

        [Required]
        public bool HealthHazard { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
