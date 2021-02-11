using System.ComponentModel.DataAnnotations;

namespace AlugaiWEB.Models
{
    public class StatuspagamentoModel
    {
        [Display(Name = "Código Status")]
        [Required(ErrorMessage = "Código da pessoa é Obrigatório")]
        public int CodigoStatusPagamento { get; set; }

        [Display(Name = "Descrição do Status")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "O valor deve ter entre 4 e 15 caracteres!!")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set; }
    }
}
