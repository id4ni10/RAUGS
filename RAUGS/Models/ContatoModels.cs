using System;
using System.ComponentModel.DataAnnotations;

namespace RAUGS.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string CGC { get; set; }

        [Display(Name = "CPF/CNPJ")]
        public string CPF_CNPJ { get; set; }

        [Display(Name = "Telefone Residencial")]
        public string Telefone_Residencial { get; set; }

        public string Endereco { get; set; }

        public string CEP { get; set; }

        [Display(Name = "Inscricao Estadual")]
        public string Inscricao_Estadual { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        [Display(Name = "Telefone Comercial")]
        public string Telefone_Comercial { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }

    public class ContatoViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cidade { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
