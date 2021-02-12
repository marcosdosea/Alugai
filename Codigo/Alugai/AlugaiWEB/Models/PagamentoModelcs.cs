using System;
using System.ComponentModel.DataAnnotations;

namespace AlugaiWEB.Models
{
    public class PagamentoModelcs
    {
        [Display(Name = "Código Pagamento")]
        [Required(ErrorMessage = "Código da pessoa é Obrigatório")]
        public int CodigoPagamento { get; set; }

        [Display(Name = "DT. Pagamento")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataPagamento { get; set; }

        [Display(Name = "Valor do Aluguel")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public double Valor { get; set; }

        [Display(Name = "DT. Vencimento")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "Forma de Pagamento")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "O valor deve ter entre 4 e 15 caracteres!!")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string FormaDePagamento { get; set; }

        [Display(Name = "Aluguel")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int CodigoAluguel { get; set; }
    }
}
