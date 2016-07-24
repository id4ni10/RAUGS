using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RAUGS.Models
{
    public class Contrato
    {
        [Required]
        [Display(Name = "cod_contrato_ctr")]
        public Int32 Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Início")]
        public DateTime dat_inicio_ctr { get; set; }

        [Display(Name = "Fim")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dat_fim_ctr { get; set; }

        [Required]
        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        public String num_valor_ctr { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public Int32 cod_tipo_contrato_tcr { get; set; }

        public int cod_licitacao_lic { get; set; }
    }

    public class ContratoView
    {
        public Int32 Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Início")]
        public DateTime dat_inicio_ctr { get; set; }

        [Display(Name = "Fim")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dat_fim_ctr { get; set; }

        [Required]
        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        public Decimal num_valor_ctr { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public String des_tipo_contrato_tcr { get; set; }
    }

    public class ContratoPublicacao
    {
        public int cod_licitacao_lic { get; set; }

        public IEnumerable<ContratoView> Contratos { get; set; }
    }
}