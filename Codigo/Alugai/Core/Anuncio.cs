using System;

namespace Core
{
    public partial class Anuncio
    {
        public int CodigoAnuncio { get; set; }
        public string Descricao { get; set; }
        public string TipoDeAnuncio { get; set; }
        public DateTime Data { get; set; }
        public int CodigoImovel { get; set; }
        public int CodigoPessoa { get; set; }

        public virtual Imovel CodigoImovelNavigation { get; set; }
        public virtual Pessoa CodigoPessoaNavigation { get; set; }
    }
}
