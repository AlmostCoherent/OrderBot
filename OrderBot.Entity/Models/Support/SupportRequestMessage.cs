using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBot.Entity.Models.Support
{
    public class SupportRequestMessage
    {
        [Key]
        public int SupportMessageId { get; set; }
        [ForeignKey("SupportRequest")]
        public int SupportId { get; set; }
        public DateTime MessageDate { get; set; }
        public string SupportMessage { get; set; }
        public virtual SupportRequest SupportRequest { get; set; }
    }
}
