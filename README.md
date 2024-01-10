[Product API.postman_collection.json](https://github.com/henriquez5/ProductAPI/files/13893990/Product.API.postman_collection.json)# ProductAPI
Api em VB.NET com operações simples de CRUD em um banco SQLSERVER

Ao clonar o repositorio abra-o no visual Studio com permissão de administrador.

Segue a instrução para criação da Tabela
CREATE TABLE Produtos
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(255),
	Categoria NVARCHAR(100),
    Preco DECIMAL(10, 2)
);

Altere o diretorio da variavel "caminhoConexao" conforme necessario

![image](https://github.com/henriquez5/ProductAPI/assets/31492149/4b451b1d-ddb2-442c-87cd-8a15f5c79711)

Ao executar o projeto irá aparecer uma janela de navegador e uma view por conta do HomeController.vb, ignore isso.
Abra o Postman e exporte a Colection 


