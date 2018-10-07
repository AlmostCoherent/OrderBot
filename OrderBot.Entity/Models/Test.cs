using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBot.Entity.Models
{
    public class Test
    {
        [Key]
        public int MyProperty { get; set; }
        public string Temp { get; set; }
    }
}
