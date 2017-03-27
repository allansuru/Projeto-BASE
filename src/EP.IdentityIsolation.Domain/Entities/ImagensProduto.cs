
namespace EP.IdentityIsolation.Domain.Entities
{
    public class ImagensProduto
    {
        //Imagem
        public int ImagemId { get; set; }
        public string ImagemTitulo { get; set; }
        public string ImagemDescricao { get; set; }
        public string FormatoImg { get; set; }
        public int ImagemTamanho { get; set; }
        public int ProdutoId { get; set; }
        public byte[] Imagem { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
