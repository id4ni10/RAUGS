using System;
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
        [Display(Name = "dat_inicio_ctr")]
        public DateTime dat_inicio_ctr { get; set; }

        [Display(Name = "dat_fim_ctr")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dat_fim_ctr { get; set; }

        [Required]
        [Display(Name = "num_valor_ctr")]
        [DataType(DataType.Currency)]
        public Decimal num_valor_ctr { get; set; }

        [Required]
        [Display(Name = "cod_tipo_contrato_tcr")]
        public Int32 cod_tipo_contrato_tcr { get; set; }

    }
}