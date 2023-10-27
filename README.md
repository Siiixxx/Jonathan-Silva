# API CRUD

#Este foi o projeto de CRUD
Esta API é uma aplicação para cadastro de produtos e categorias.

# Técnologias usadas
as técnologias usadas para fazer o crud foi linguagem de programação em C# e banco de dados o SQL Server.


#Método	URL	Descrição
POST	/	Cria um pedido usando as informações enviadas dentro do arquivo request body.
GET	/	Retorna as informações do pedidos.
GET	/:id	Retorna o objeto de pedido específico id.
DELETE	/order/:id	Remove o objeto de pedido específico id e retorna status 204.
PUT	/order/:id	Atualiza o objeto de pedido específico id usando o arquivo request bodye retorna o usuário modificado.
