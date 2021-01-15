using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlugaiWEB.Models
{
    public class SolicitacaoManuntecaoModel
    {

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código da manuntenção é Obrigatório")]
        public int CodigoManuntencao { get; set; }

        [Display(Name = "Tipo Da Manuntenção")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "O Tipo deve ter entre 3 e 50 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string TipoDeManuntencao { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "A descrição deve ter entre 3 e 250 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set; }

        [Display(Name = "Valor Da Manuntenção")]
        [Required(ErrorMessage = "O valor da manuntenção é Obrigatório")]
        public double Valor { get; set; }

        [Display(Name = "Status Da Manuntenção")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "O Status deve ter entre 3 e 25 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string StatusManuntencao { get; set; }

        [Display(Name = "Comodo Do Imóvel")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "A locolização de onde a manuntenção será feita deve ter entre 3 e 45 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string ComodoImovel { get; set; }

        [Display(Name = "Código Da Pessoa")]
        [Required(ErrorMessage = "Código é Obrigatório")]
        public int CodigoPessoa { get; set; }

        [Display(Name = "Código Do Imovel")]
        [Required(ErrorMessage = "Código é Obrigatório")]
        public int CodigoImovel { get; set; }

   
    }
}
