using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Anuncio = new HashSet<Anuncio>();
            Manuntencao = new HashSet<Manuntencao>();
            Pessoaaluguel = new HashSet<Pessoaaluguel>();
        }

        public int CodigoPessoa { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rg { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string EstadoUf { get; set; }
        public int NumeroDoEndereco { get; set; }
        public int CodigoTipoPessoa { get; set; }

        public virtual Tipopessoa CodigoTipoPessoaNavigation { get; set; }
        public virtual ICollection<Anuncio> Anuncio { get; set; }
        public virtual ICollection<Manuntencao> Manuntencao { get; set; }
        public virtual ICollection<Pessoaaluguel> Pessoaaluguel { get; set; }
    }
}
