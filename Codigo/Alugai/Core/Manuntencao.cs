using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Manuntencao
    {
        public int CodigoManuntencao { get; set; }
        public string TipoDeManuntencao { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public string StatusManuntencao { get; set; }
        public string ComodoImovel { get; set; }
        public int CodigoPessoa { get; set; }
        public int CodigoImovel { get; set; }
        public int StatusManuntencaoCodigoStatusManuntencao { get; set; }

        public virtual Imovel CodigoImovelNavigation { get; set; }
        public virtual Pessoa CodigoPessoaNavigation { get; set; }
        public virtual Statusmanuntencao StatusManuntencaoCodigoStatusManuntencaoNavigation { get; set; }
    }
}
