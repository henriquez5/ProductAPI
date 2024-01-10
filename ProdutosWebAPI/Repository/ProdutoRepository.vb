Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Razor.Tokenizer
Imports Newtonsoft.Json

Public Class ProdutoRepository
    Implements IProdutoRepository

    Private conexaoDB As ConexaoDB

    Public Sub New()
        conexaoDB = New ConexaoDB()
    End Sub

    Public Function ObterProdutos(ByVal filtro As String) Implements IProdutoRepository.ObterProdutos
        Using conexao As SqlConnection = conexaoDB.CriarConexao()
            conexao.Open()

            Dim produtos As New List(Of Produto)()

            Try
                Dim query As String = "SELECT Id, Nome, Categoria, Preco FROM Produtos WHERE Nome LIKE @Filtro OR Categoria LIKE @Filtro"


                Using commandSql As New SqlCommand(query, conexao)

                    commandSql.Parameters.AddWithValue("@Filtro", "%" & filtro & "%")

                    Using reader As SqlDataReader = commandSql.ExecuteReader()

                        While reader.Read()
                            Dim produto As New Produto() With {
                                .Id = CInt(reader("Id")),
                                .Nome = reader("Nome").ToString(),
                                .Categoria = reader("Categoria").ToString(),
                                .Preco = Convert.ToDecimal(reader("Preco"))
                            }
                            produtos.Add(produto)
                        End While

                    End Using
                End Using

                conexao.Close()

                Return produtos
            Catch ex As Exception

                conexao.Close()

                Return ex.Message
            End Try
        End Using
    End Function

    Public Function ObterProdutoPorId(ByVal produtoId As Integer, ByVal conexao As SqlConnection, ByVal transaction As SqlTransaction) As Produto
        Dim produto As Produto = Nothing

        Dim query As String = "SELECT Id, Nome, Categoria, Preco FROM Produtos WHERE Id = @ProdutoId"

        Using commandSql As New SqlCommand(query, conexao, transaction)
            commandSql.Parameters.AddWithValue("@ProdutoId", produtoId)

            Using reader As SqlDataReader = commandSql.ExecuteReader()
                If reader.Read() Then
                    produto = New Produto() With {
                    .Id = CInt(reader("Id")),
                    .Nome = reader("Nome").ToString(),
                    .Categoria = reader("Categoria").ToString(),
                    .Preco = Convert.ToDecimal(reader("Preco"))
                }
                End If
            End Using
        End Using

        Return produto
    End Function

    Public Function AdicionarProduto(ByVal novoProduto As Produto) Implements IProdutoRepository.AdicionarProduto

        Using conexao As SqlConnection = conexaoDB.CriarConexao()
            conexao.Open()

            Using transaction As SqlTransaction = conexao.BeginTransaction()
                Try
                    Dim query As String = "INSERT INTO Produtos (Nome, Categoria, Preco) OUTPUT INSERTED.Id VALUES (@Valor1, @Valor2, @Valor3)"

                    Using commandSql As New SqlCommand(query, conexao, transaction)
                        commandSql.Parameters.AddWithValue("@Valor1", novoProduto.Nome)
                        commandSql.Parameters.AddWithValue("@Valor2", novoProduto.Categoria)
                        commandSql.Parameters.AddWithValue("@Valor3", novoProduto.Preco)

                        Dim novoId As Integer = CInt(commandSql.ExecuteScalar())

                        novoProduto.Id = novoId
                    End Using

                    transaction.Commit()

                    conexao.Close()

                    Return novoProduto
                Catch ex As Exception
                    transaction.Rollback()

                    conexao.Close()

                    Return ex.Message
                End Try
            End Using
        End Using
    End Function

    Public Function AtualizarProduto(ByVal idProduto As Integer, ByVal produtoAtualizado As Produto) Implements IProdutoRepository.AtualizarProduto
        Using conexao As SqlConnection = conexaoDB.CriarConexao()
            conexao.Open()

            Using transaction As SqlTransaction = conexao.BeginTransaction()
                Try
                    Dim query As String = "UPDATE Produtos SET Nome=@Valor1, Categoria=@Valor2, Preco=@Valor3 WHERE Id = @ProdutoId"

                    Using commandSql As New SqlCommand(query, conexao, transaction)
                        commandSql.Parameters.AddWithValue("@Valor1", produtoAtualizado.Nome)
                        commandSql.Parameters.AddWithValue("@Valor2", produtoAtualizado.Categoria)
                        commandSql.Parameters.AddWithValue("@Valor3", produtoAtualizado.Preco)
                        commandSql.Parameters.AddWithValue("@ProdutoId", idProduto)

                        Dim verifica As Integer = commandSql.ExecuteNonQuery()

                        If verifica > 0 Then
                            transaction.Commit()

                            conexao.Close()
                        Else
                            Throw New Exception("Atualização falhou verifique se passou o Id corretamente!!")
                        End If
                    End Using

                    produtoAtualizado.Id = idProduto

                    Return produtoAtualizado
                Catch ex As Exception
                    transaction.Rollback()

                    conexao.Close()

                    Return ex.Message
                End Try
            End Using
        End Using
    End Function

    Public Function ExcluirProduto(ByVal produtoId As Integer) Implements IProdutoRepository.ExcluirProduto
        Dim produtoExcluido As Produto = Nothing

        Using conexao As SqlConnection = conexaoDB.CriarConexao()
            conexao.Open()

            Using transaction As SqlTransaction = conexao.BeginTransaction()
                Try
                    produtoExcluido = ObterProdutoPorId(produtoId, conexao, transaction)

                    If produtoExcluido IsNot Nothing Then

                        Dim query As String = "DELETE FROM Produtos WHERE Id = @ProdutoId"
                        Using commandSql As New SqlCommand(query, conexao, transaction)
                            commandSql.Parameters.AddWithValue("@ProdutoId", produtoId)
                            commandSql.ExecuteNonQuery()
                        End Using
                        transaction.Commit()
                    Else

                        transaction.Rollback()
                    End If
                Catch ex As Exception
                    transaction.Rollback()
                    Return Nothing
                End Try
            End Using
        End Using

        Return produtoExcluido
    End Function

End Class


