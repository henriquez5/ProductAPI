Public Interface IProdutoRepository

    Function ObterProdutos(ByVal filtro As String)

    Function AdicionarProduto(ByVal novoProduto As Produto)

    Function AtualizarProduto(ByVal idProduto As Integer, ByVal produtoAtualizado As Produto)

    Function ExcluirProduto(ByVal id As Integer)

End Interface


