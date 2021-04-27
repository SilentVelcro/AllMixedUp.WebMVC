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
        public Guid OwnerId { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
    }
}
