using System;
using System.ComponentModel.DataAnnotations;

namespace RAUGS.Models
{
    public class Licitacao
    {
        [Required]
        [Display(Name = "cod_licitacao_lic")]
        public Int32 cod_licitacao_lic { get; set; }

        [Required]
        [Display(Name = "dat_licitacao_lic")]
        public String dat_licitacao_lic { get; set; }

        [Required]
        [Display(Name = "cod_cliente_cli")]
        public Int32 cod_cliente_cli { get; set; }

        [Required]
        [Display(Name = "cod_tipo_licitacao_tli")]
        public Int32 cod_tipo_licitacao_tli { get; set; }

        [Required]
        [Display(Name = "dat_inicio_contrato_lic")]
        public String dat_inicio_contrato_lic { get; set; }

        [Display(Name = "dat_fim_contrato_lic")]
        public String dat_fim_contrato_lic { get; set; }

        [Display(Name = "num_mes_lic")]
        public Int32 num_mes_lic { get; set; }

        [Required]
        [Display(Name = "num_valor_lic")]
        public Decimal num_valor_lic { get; set; }

        [Required]
        [Display(Name = "tip_status_lic")]
        public Boolean tip_status_lic { get; set; }
    }
}