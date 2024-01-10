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
Link : [Uploading Pro{
	"info": {
		"_postman_id": "ded52cd4-5331-4a85-8a37-5bf692db4f0b",
		"name": "Product API",
		"schema": "https://schema.getpostman.com/json/collection/v2.1.0/collection.json",
		"_exporter_id": "32157045"
	},
	"item": [
		{
			"name": "Obter Produtos",
			"protocolProfileBehavior": {
				"disableBodyPruning": true
			},
			"request": {
				"method": "GET",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{\r\n  \"Nome\": \"Guarda Roupa Feminino\",\r\n  \"Categoria\": \"Moveis\",\r\n  \"Preco\": 800\r\n}\r\n\r\n//http://localhost:52079/api/produtos?filtro=Eletronico",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "http://localhost:52079/api/produtos",
					"protocol": "http",
					"host": [
						"localhost"
					],
					"port": "52079",
					"path": [
						"api",
						"produtos"
					]
				}
			},
			"response": []
		},
		{
			"name": "Adicionar Produto",
			"request": {
				"method": "POST",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{\r\n  \"Nome\": \"Guarda Roupa Masculino\",\r\n  \"Categoria\": \"Moveis\",\r\n  \"Preco\": 800\r\n}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "http://localhost:52079/api/produtos",
					"protocol": "http",
					"host": [
						"localhost"
					],
					"port": "52079",
					"path": [
						"api",
						"produtos"
					]
				}
			},
			"response": []
		},
		{
			"name": "Atualizar Produto",
			"request": {
				"method": "PUT",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{\r\n  \"Nome\": \"Guarda Roupa Feminino\",\r\n  \"Categoria\": \"Moveis\",\r\n  \"Preco\": 560\r\n}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "http://localhost:52079/api/produtos/7",
					"protocol": "http",
					"host": [
						"localhost"
					],
					"port": "52079",
					"path": [
						"api",
						"produtos",
						"7"
					]
				}
			},
			"response": []
		},
		{
			"name": "Deletar Produto",
			"request": {
				"method": "DELETE",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "http://localhost:52079/api/produtos/6",
					"protocol": "http",
					"host": [
						"localhost"
					],
					"port": "52079",
					"path": [
						"api",
						"produtos",
						"6"
					]
				}
			},
			"response": []
		}
	]
}duct API.postman_collection.json…]()

