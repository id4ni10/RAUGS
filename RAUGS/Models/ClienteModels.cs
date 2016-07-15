using System;
using System.ComponentModel.DataAnnotations;

namespace RAUGS.Models
{
    public class Cliente
    {
        [Required]
        [Display(Name = "cod_cliente_cli")]
        public Int32 Id { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public String des_cliente_cli { get; set; }
    }
}