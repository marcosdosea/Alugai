using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlugaiWEB.Models
{
    public class DespesasModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código é Obrigatório")]
        public int CodigoDespesas { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "A descrição deve conter entre 3 e 200 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string DescricaoDespesa { get; set; }

        [Display(Name = "Tipo De Despesa")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "Tipo De Despesa deve conter entre 3 e 45 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string TipoDeDespesa { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Valor é Obrigatório")]
        public int Valor { get; set; }

        [Display(Name = "Descrição Imóvel")]
        [Required(ErrorMessage = "Descrição do imóvel é Obrigatório")]
        public int CodigoImovel { get; set; }

        public string Descricao { get; set; }
    }
}
