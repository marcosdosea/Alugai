using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Despesas
    {
        public int CodigoDespesas { get; set; }
        public string TipoDeDespesa { get; set; }
        public int Valor { get; set; }
        public string DescricaoDespesa { get; set; }
        public int CodigoImovel { get; set; }

        public virtual Imovel CodigoImovelNavigation { get; set; }
    }
}
