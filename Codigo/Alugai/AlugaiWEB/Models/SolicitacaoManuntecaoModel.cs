﻿using System.ComponentModel.DataAnnotations;

namespace AlugaiWEB.Models
{
    public class SolicitacaoManuntecaoModel
    {

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código da manutenção é Obrigatório")]
        public int CodigoManuntencao { get; set; }

        [Display(Name = "Tipo Da Manutenção")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "O Tipo deve ter entre 3 e 50 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string TipoDeManuntencao { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "A descrição deve ter entre 3 e 250 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set; }

        [Display(Name = "Valor da Manutenção")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public double Valor { get; set; }

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

        [Display(Name = "Status Atual Da Manutenção Do Imovel")]
        [Required(ErrorMessage = "Código é Obrigatório")]
        public int StatusManutencao { get; set; }


    }
}
