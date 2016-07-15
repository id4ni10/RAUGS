using System;
using System.ComponentModel.DataAnnotations;

namespace RAUGS.Models
{
    public class ProdutoModel
    {
        [Required]
        [Display(Name = "cod_produto_pro")]
        public Int32 cod_produto_pro { get; set; }

        [Required]
        [Display(Name = "des_produto_pro")]
        public String des_produto_pro { get; set; }
    }
}