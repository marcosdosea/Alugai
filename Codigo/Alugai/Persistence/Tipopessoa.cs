using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Tipopessoa
    {
        public Tipopessoa()
        {
            Pessoa = new HashSet<Pessoa>();
        }

        public int CodigoTipoPessoa { get; set; }
        public string TipoPessoa1 { get; set; }

        public virtual ICollection<Pessoa> Pessoa { get; set; }
    }
}
