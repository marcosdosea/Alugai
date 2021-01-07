using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Statusimovel
    {
        public Statusimovel()
        {
            Imovel = new HashSet<Imovel>();
        }

        public int CodigoStatusImovel { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Imovel> Imovel { get; set; }
    }
}
