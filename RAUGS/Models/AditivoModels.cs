using System;
using System.ComponentModel.DataAnnotations;

namespace RAUGS.Models
{
    public class AditivoModel
    {
        [Required]
        [Display(Name = "cod_aditivo_adi")]
        public Int32 cod_aditivo_adi { get; set; }

        [Required]
        [Display(Name = "cod_licitacao_lic")]
        public Int32 cod_licitacao_lic { get; set; }

        [Required]
        [Display(Name = "dat_inicio_adi")]
        public String dat_inicio_adi { get; set; }

        [Display(Name = "dat_fim_adi")]
        public String dat_fim_adi { get; set; }

        [Required]
        [Display(Name = "num_valor_adi")]
        public Decimal num_valor_adi { get; set; }
    }
}