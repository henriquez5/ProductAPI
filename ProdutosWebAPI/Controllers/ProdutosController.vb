﻿Imports System.Net.Http
Imports System.Net
Imports System.Web.Http
Imports System.Runtime.InteropServices

Namespace ProdutosWebAPI

    Public Class ProdutosController
        Inherits ApiController

        Private _produtoService As IProdutoService = New ProdutoService

        <HttpGet>
        Public Function ListarClientes(ByVal filtro As String)
            Try
                Dim buscarProdutos As List(Of Produto) = _produtoService.ObterProdutos(filtro)

                If buscarProdutos.Count = 0 Then
                    Throw New Exception("Nenhum produto localizado")
                End If

                Return buscarProdutos
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        <HttpPost>
        Public Function AdicionarProduto(<FromBody> ByVal novoProduto As Produto)
            Try
                Dim produtoAdd As Produto = _produtoService.AdicionarProduto(novoProduto)

                If produtoAdd Is Nothing Then
                    Dim resp = New HttpResponseMessage(HttpStatusCode.NotFound)
                    Throw New HttpResponseException(resp)
                End If

                Return produtoAdd
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        <HttpPut>
        Public Function AtualizarCliente(ByVal id As Integer, <FromBody> ByVal atualizarProduto As Produto)
            Try
                Dim produtoUpdate As Produto = _produtoService.AtualizarProduto(id, atualizarProduto)

                If produtoUpdate Is Nothing Then
                    Dim resp = New HttpResponseMessage(HttpStatusCode.NotFound)
                    Throw New HttpResponseException(resp)
                End If

                Return produtoUpdate
            Catch ex As Exception
                Return ex
            End Try
        End Function

        <HttpDelete>
        Public Function DeletarCliente(ByVal id As Integer)
            Try
                Dim produtoDeletar As Produto = _produtoService.RemoverProduto(id)

                If produtoDeletar Is Nothing Then
                    Throw New Exception("Nenhum Cliente foi deletado.")
                End If

                Return produtoDeletar
            Catch ex As Exception
                Return ex
            End Try
        End Function

    End Class
End Namespace