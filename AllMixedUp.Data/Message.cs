using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMixedUp.Data
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public int FromID { get; set; }
        public int ToID { get; set; }

        [Required]
        public string Body { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
