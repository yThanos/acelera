using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo.DataModels
{
    public class Email
    {
        public int id { get; set; }
        public String email { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
