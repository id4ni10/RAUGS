using System;
using System.ComponentModel.DataAnnotations;

namespace RAUGS.Models
{
    public class ClienteModel
    {
        [Required]
        [Display(Name = "cod_cliente_cli")]
        public Int32 cod_cliente_cli { get; set; }

        [Required]
        [Display(Name = "des_cliente_cli")]
        public String des_cliente_cli { get; set; }
    }
}