using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Statuspagamento
    {
        public Statuspagamento()
        {
            Aluguel = new HashSet<Aluguel>();
        }

        public int CodigoStatusPagamento { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Aluguel> Aluguel { get; set; }
    }
}
