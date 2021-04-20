using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Models
{
    public class MessageDetail
    {
        [Display(Name = "ID")]
        public int MessageID { get; set; }

        [Display(Name = "From")]
        public int UserID { get; set; }

        [Display(Name = "Body")]
        public string Body { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedDate { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
