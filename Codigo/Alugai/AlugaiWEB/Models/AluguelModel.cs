using System.ComponentModel.DataAnnotations;

namespace AlugaiWEB.Models
{
    public class AluguelModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código é Obrigatório")]
        public int CodigoAluguel { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "A descrição deve conter entre 3 e 250 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set; }

        [Display(Name = "Status Pagamento")]
        [Required(ErrorMessage = "Status Pagamento é Obrigatório")]
        public int CodigoStatusPagamento { get; set; }

    }
}
