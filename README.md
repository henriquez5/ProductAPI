# ProductAPI
Api em VB.NET com operações simples de CRUD em um banco SQLSERVER

Segue a instrução para criação da Tabela

CREATE TABLE Produtos
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(255),
	Categoria NVARCHAR(100),
    Preco DECIMAL(10, 2)
);
