using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EP.IdentityIsolation.MVC.ViewModels
{
    public class ClienteViewModel
    {
        //view model n deve ter comportamentos, já tem na DOMAIN
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório *")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório *")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        [DisplayName("Sobrenome")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório *")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Digite um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
    
}