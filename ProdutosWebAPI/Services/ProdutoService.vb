Public Class ProdutoService
    Implements IProdutoService
    Private _produtoRepository As IProdutoRepository = New ProdutoRepository

    Public Function ObterProdutos(ByVal filtro As String) As List(Of Produto) Implements IProdutoService.ObterProdutos
        Try
            If String.IsNullOrEmpty(filtro) Then
                filtro = ""
            End If

            Dim buscarProdutos As New List(Of Produto)()

            buscarProdutos = _produtoRepository.ObterProdutos(filtro)

            Return buscarProdutos
        Catch ex As Exception
            Throw New Exception("Houve um erro ao buscar o(s) cliente(s): " & ex.Message)
        End Try
    End Function

    Public Function AdicionarProduto(ByVal novoProduto As Produto) As Produto Implements IProdutoService.AdicionarProduto
        Try

            Dim resultProdutoAdicionar As New Produto()

            If novoProduto.Preco <= 0 Then
                Throw New Exception("Preço invalido!! Digite um preço valido ou maior que 0 R$")
            End If

            resultProdutoAdicionar = _produtoRepository.AdicionarProduto(novoProduto)

            Return resultProdutoAdicionar
        Catch ex As Exception
            Throw New Exception("Houve um erro ao adicionar o produto: " & ex.Message)
        End Try
    End Function

    Public Function AtualizarProduto(ByVal idProduto As Integer, ByVal produtoAtualizado As Produto) As Produto Implements IProdutoService.AtualizarProduto
        Try
            Dim resultProdutoAtualizar As New Produto()

            If produtoAtualizado.Preco <= 0 Then
                Throw New Exception("Preço invalido!! Digite um preço valido ou maior que 0 R$")
            End If

            resultProdutoAtualizar = _produtoRepository.AtualizarProduto(idProduto, produtoAtualizado)

            Return resultProdutoAtualizar
        Catch ex As Exception
            Throw New Exception("Houve um erro ao atualizar o cliente: " & ex.Message)
        End Try
    End Function

    Public Function RemoverProduto(ByVal id As Integer) Implements IProdutoService.RemoverProduto
        Try
            Dim resultProdutoRemover As New Produto()

            resultProdutoRemover = _produtoRepository.ExcluirProduto(id)

            Return resultProdutoRemover
        Catch ex As Exception
            Throw New Exception("Houve um erro ao remover o cliente: " & ex.Message)
        End Try
    End Function
End Class
