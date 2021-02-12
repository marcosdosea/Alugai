using System;
using System.ComponentModel.DataAnnotations;

namespace AlugaiWEB.Models
{
    public class PessoaModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código da pessoa é Obrigatório")]
        public int CodigoPessoa { get; set; }

        [Display(Name ="Nome")]
        [StringLength(50, MinimumLength =3,ErrorMessage ="O nome deve ter entre 3 e 50 caracteres")]
        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "O nome deve ter entre 10 e 50 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "O nome deve ter entre 8 e 20 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Senha { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "O nome deve ter entre 8 e 20 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get; set; }

        [Display(Name = "CPF")]
        [StringLength(15, MinimumLength = 11, ErrorMessage = "O nome deve ter entre 11 e 15 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cpf { get; set; }

        [Display(Name = "Sexo")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 e 20 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Sexo { get; set; }

        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "RG")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 e 15 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Rg { get; set; }

        [Display(Name = "Rua")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 e 45 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Rua { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 e 45 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 e 30 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cidade { get; set; }

        [Display(Name = "CEP")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 e 15 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cep { get; set; }

        [Display(Name = "Estado UF")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 25 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string EstadoUf { get; set; }

        [Display(Name = "Numero Do Endereço")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int NumeroDoEndereco { get; set; }

        [Display(Name = "Tipo Pessoa")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int TipoPessoa { get; set; }
    }
}
