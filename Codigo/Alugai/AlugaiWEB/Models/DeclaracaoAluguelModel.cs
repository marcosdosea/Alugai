using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlugaiWEB.Models
{
    public class DeclaracaoAluguelModel
    {
        [Display(Name = "Codigo do Aluguel")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int CodigoAluguel { get; set; }
        [Display(Name = "Descricao do Aluguel")]
        [StringLength(250, MinimumLength = 15, ErrorMessage = "O valor deve ter entre 15 e 250 caracteres!!")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set; }
        [Display(Name = "Codigo do Pagamento")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int CodigoStatusPagamento { get; set; }
    }
}
