Imports System.Data.SqlClient
Imports System.Data

Public Class ConexaoDB
    Private caminhoConexao As String = "Data Source=DESKTOP-3O1CG63;Initial Catalog=ProdutosManagement;Integrated Security=True;"

    Public Function CriarConexao() As SqlConnection
        Return New SqlConnection(caminhoConexao)
    End Function

End Class