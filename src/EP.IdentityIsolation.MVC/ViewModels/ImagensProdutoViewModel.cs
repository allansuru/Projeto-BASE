using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EP.IdentityIsolation.MVC.ViewModels
{
    public class ImagensProdutoViewModel
    {
        [Key]
        public int ImagemId { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório *")]
        [MaxLength(80, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo de {0} caracteres")]
        public string ImagemTitulo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório *")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo de {0} caracteres")]
        public string ImagemDescricao { get; set; }
        public string FormatoImg { get; set; }

        public int ImagemTamanho { get; set; }

        public int ProdutoId { get; set; }

        public byte[] Imagem { get; set; }

        public virtual ProdutoViewModel Produto { get; set; }


    }
}