Imports System.Data.SqlClient
Imports System.Data

Public Class ConexaoDB
    Private caminhoConexao As String = "Data Source=DESKTOP-3O1CG63;Initial Catalog=ProdutosManagement;Integrated Security=True;"

    Public Function CriarConexao() As SqlConnection
        Return New SqlConnection(caminhoConexao)
    End Function

    Public Sub Criar(produto As Produto, conexao As SqlConnection)

        Dim query As String = "INSERT INTO Produtos (Nome, Categoria, Preco) OUTPUT INSERTED.Id VALUES (@Valor1, @Valor2, @Valor3)"

        Using dataAdapter As New SqlDataAdapter()
            Using commandSql As New SqlCommand(query, conexao)
                commandSql.Parameters.AddWithValue("@Valor1", produto.Nome)
                commandSql.Parameters.AddWithValue("@Valor2", produto.Categoria)
                commandSql.Parameters.AddWithValue("@Valor3", produto.Preco)

                dataAdapter.InsertCommand = commandSql

                'commandSql.ExecuteNonQuery()

                Dim novoId As Integer = CInt(commandSql.ExecuteScalar())

                produto.Id = novoId

            End Using
        End Using
    End Sub
End Class