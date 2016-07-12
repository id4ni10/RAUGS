using System;
using System.ComponentModel.DataAnnotations;

namespace RAUGS.Models
{
    public class Licitacao
    {
        [Required]
        [Display(Name = "cod_licitacao_lic")]
        public Int32 Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Licita��o")]
        public DateTime dat_licitacao_lic { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public Int32 cod_cliente_cli { get; set; }

        [Required]
        [Display(Name = "Tipo Licita��o")]
        public Int32 cod_tipo_licitacao_tli { get; set; }

        [Display(Name = "M�s")]
        public Int32 num_mes_lic { get; set; }

        [Required]
        [Display(Name = "Valor")]
        public Decimal num_valor_lic { get; set; }

        [Required]
        [Display(Name = "Ativo")]
        public Boolean tip_status_lic { get; set; }

        [Required]
        [Display(Name = "N�mero")]
        public Int32 cod_numero_num { get; set; }
    }

    public class LicitacaoView
    {
        public Int32 Id { get; set; }

        [Display(Name = "Data Licita��o")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime dat_licitacao_lic { get; set; }

        [Display(Name = "Cliente")]
        public String des_cliente_cli { get; set; }

        [Display(Name = "Valor")]
        public Decimal num_valor_lic { get; set; }

        [Display(Name = "Ativo")]
        public String tip_status_lic { get; set; }

        [Display(Name = "N�mero")]
        public Int32 cod_numero_num { get; set; }
    }
}