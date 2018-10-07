using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBot.Entity.Models.Support
{
    [Serializable]
    public class SupportRequest
    {
        [Key]
        public int SupportId { get; set; }
        public string Email { get; set; }
        public int OrderNumber { get; set; }
        public SupportStatus Status { get; set; }
        public virtual ICollection<SupportRequestMessage> SupportRequestMessages { get; set; }
        [NotMapped]
        public string Message { get; set; } 
    }
}
