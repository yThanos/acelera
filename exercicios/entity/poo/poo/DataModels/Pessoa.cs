﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo.DataModels
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
    }
}
