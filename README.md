
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

Ao executar o projeto irá aparecer uma janela de navegador e uma view por conta do HomeController.vb , deixe-o rodando e o ignore.
Abra o Postman e exporte a Colection 
[Product API.postman_collection.json](https://github.com/henriquez5/ProductAPI/files/13893990/Product.API.postman_collection.json)# ProductAPI

GET (http://localhost:52079/api/produtos)
No caso de Obter os produtos voce pode colocar um filtro ou não
http://localhost:52079/api/produtos?filtro=Eletronico a partir desse filtro ele ira pesquisar no banco pelo Nome e pela Categoria.
Caso não informe ele retornará todos os dados do banco => http://localhost:52079/api/produtos

POST
Ele irá realizar uma inserção de acordo com o modelo JSON que ta no arquivo de colection
Caso voce insira um valor negativo, 0 ou string será disparado um erro

PUT (http://localhost:52079/api/produtos/{id})
Atualização de um produto existente

DELETE (http://localhost:52079/api/produtos/{id})
Exclusão de um produto existente
O produto que foi excluido será retornado apos finalizada a requisição


