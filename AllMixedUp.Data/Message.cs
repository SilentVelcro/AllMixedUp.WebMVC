using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Data
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        [ForeignKey("From")]
        public int FromID { get; set; }
        public virtual User From { get; set; }

        [ForeignKey("To")]
        public int ToID { get; set; }
        public virtual User To { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
    }
}
