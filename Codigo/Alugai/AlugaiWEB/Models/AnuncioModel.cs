using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlugaiWEB.Models
{
    public class AnuncioModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código é Obrigatório")]
        public int CodigoAnuncio { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "A descrição deve conter entre 3 e 250 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set; }

        [Display(Name = "Tipo De Anuncio")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Tipo De Anuncio deve conter entre 3 e 15 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string TipoDeAnuncio { get; set; }

        [Display(Name = "Imóvel")]
        [Required(ErrorMessage = "Imóvel é Obrigatório")]
        public int CodigoImovel { get; set; }

        [Display(Name = "Pessoa")]
        [Required(ErrorMessage = "Pessoa é Obrigatório")]
        public int CodigoPessoa { get; set; }
    }
}
