select * from Produto
inner join ImagensProduto
on
Produto.ProdutoId = ImagensProduto.ProdutoId where Produto.Nome = 'Ferrari'