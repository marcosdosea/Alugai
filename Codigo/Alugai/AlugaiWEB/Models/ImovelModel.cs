using System.ComponentModel.DataAnnotations;

namespace AlugaiWEB.Models
{
    public class ImovelModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int CodigoImovel { get; set; }

        [Display(Name = "Tipo")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "O valor deve ter entre 4 e 15 caracteres!!")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string TipoImovel { get; set; }

        [Display(Name = "Quartos")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int QuantidadeDeQuartos { get; set; }

        [Display(Name = "Banheiros")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int QuantidadeDeBanheiros { get; set; }

        [Display(Name = "Quantidade de suites")]
        public int? QuantidadeDeSuites { get; set; }

        [Display(Name = "Area quadrada do imovel")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public float AreaQuadrada { get; set; }

        [Display(Name = "Quantidade de andares")]
        public int? QuantidadeDeAndares { get; set; }

        [Display(Name = "Quantidade de garagens")]
        public int? QuantidadeDeGaragem { get; set; }

        [Display(Name = "Descrição do Imovel")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "O valor deve ter entre 10 e 250 caracteres!!")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public double ValorDoAluguel { get; set; }

        [Display(Name = "Valor do Condominio")]
        public double? ValorDoCondominio { get; set; }

        [Display(Name = "Valor do IPTU")]
        public double? ValorDoIptu { get; set; }

        [Display(Name = "Quantidade de Cozinha")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int QuantidadeCozinha { get; set; }

        [Display(Name = "Quantidade de Sala")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int QuantidadeDeSala { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "O valor deve ter entre 5 e 45 caracteres!!")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "O valor deve ter entre 5 e 45 caracteres!!")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "O valor deve ter entre 5 e 45 caracteres!!")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string EstadoUf { get; set; }

        [Display(Name = "Rua")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O valor deve ter entre 10 e 100 caracteres!!")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Rua { get; set; }

        [Display(Name = "Numero do Imovel")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Numero { get; set; }

        [Display(Name = "Complemento do Endereço")]
        [StringLength(200, MinimumLength = 0, ErrorMessage = "O valor deve ter no maximo 200 caracteres!!")]
        public string ComplementoEndereco { get; set; }

        [Display(Name = "CEP")]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "O valor deve ter entre 9 e 15 caracteres!!")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cep { get; set; }

        [Display(Name = "Status Atual do Imovel")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int StatusImovel { get; set; }
    }
}
