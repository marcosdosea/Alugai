using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Imovel
    {
        public Imovel()
        {
            Aluguelimovel = new HashSet<Aluguelimovel>();
            Anuncio = new HashSet<Anuncio>();
            Despesas = new HashSet<Despesas>();
            Manuntencao = new HashSet<Manuntencao>();
        }

        public int CodigoImovel { get; set; }
        public string TipoImovel { get; set; }
        public int QuantidadeDeQuartos { get; set; }
        public int QuantidadeDeBanheiros { get; set; }
        public int? QuantidadeDeSuites { get; set; }
        public float AreaQuadrada { get; set; }
        public int? QuantidadeDeAndares { get; set; }
        public int? QuantidadeDeGaragem { get; set; }
        public string Descricao { get; set; }
        public double ValorDoAluguel { get; set; }
        public double? ValorDoCondominio { get; set; }
        public double? ValorDoIptu { get; set; }
        public int QuantidadeCozinha { get; set; }
        public int QuantidadeDeSala { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string EstadoUf { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string ComplementoEndereco { get; set; }
        public string Cep { get; set; }
        public int StatusImovel { get; set; }

        public virtual Statusimovel StatusImovelNavigation { get; set; }
        public virtual ICollection<Aluguelimovel> Aluguelimovel { get; set; }
        public virtual ICollection<Anuncio> Anuncio { get; set; }
        public virtual ICollection<Despesas> Despesas { get; set; }
        public virtual ICollection<Manuntencao> Manuntencao { get; set; }
    }
}
