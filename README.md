
# .NET Assesment Gustavo Aparecido

 Este projeto é uma API RESTful que permite gerenciar um CRUD da entidade produto. A API é construída usando o framework ASP.NET Core e os bancos de dados SQL Server e MongoDB, assim como também trabalha com mensagerias usando RabbitMQ.

## Arquitetura Limpa

A API é construída usando a arquitetura limpa. A arquitetura limpa é um modelo de arquitetura de software que divide uma aplicação por resposabilidades e evita o acoplamento entre as mesmas.

A camada de API é responsável por lidar com as solicitações HTTP do cliente.
A camada de aplicação é responsável por processar as solicitações e retornar as respostas.
A camada de dados é responsável por acessar e armazenar os dados no banco de dados.
A camada de domínio é responsável por representar os domínios da aplicação.
A camada de IoC é responsável por toda injeção de dependencias evitando o acoplamento por toda a aplicação.

## Instalação

Para rodar a API você precisara ter em sua maquina os seguintes programas:

[Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/) ou [Visual Studio Code](https://code.visualstudio.com/);

[SQL Server](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16);

[MongoDB](https://www.mongodb.com/try/download/community);

[RabbitMQ](https://www.rabbitmq.com/download.html);

Após isso basta realizar o clone do repositório para sua maquina:

```bash
git clone https://github.com/GustavoCremonez/.net-assesment-gustavo-aparecido.git
```

Abrir o projeto com seu editor de código
Executar as migrations para criar e atualizar o banco SQL

Com o CLI do dotnet:
```bash
dotnet ef database update
```

ou

Com o console do package manager:
```bash
Update-Database
```

**Observação: precisa ser alterado no arquivo appsettings.json as connectionsstrings com seus dados tanto do SQL Server quanto do MongoDB


após isso basta rodar a solução com o Projeto DotNETAssesmentGA.API sendo o start project;



## Documentação da API

#### Retorna todos os produtos do banco SQL Server

```http
    GET /api/1/product/GetAll
```

#### Retorna todos os produtos do banco MongoDB

```http
    GET /api/2/product/GetAll
```


#### Retorna um produto do banco SQL Server

```http
    GET /api/1/product/Get?id=<string>
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | **Obrigatório**. O ID do produto que você quer |


#### Retorna um produto do banco MongoDB

```http
    GET /api/2/product/Get?id=<string>
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | **Obrigatório**. O ID do produto que você quer |


#### Cadastra um produto do banco SQL Server
```http
    POST /api/1/product
```
Body:
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `name`      | `string` | **Obrigatório**. O Nome do produto que você quer |
| `description`      | `string` | **Obrigatório**. A Descrição do produto que você quer |
| `price`      | `number` | **Obrigatório**. O valor não pode ser negativo |

#### Cadastra um produto do banco MongoDB

```http
    POST /api/2/product
```
Body:
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `name`      | `string` | **Obrigatório**. O Nome do produto que você quer |
| `description`      | `string` | **Obrigatório**. A Descrição do produto que você quer |
| `price`      | `number` | **Obrigatório**. O valor não pode ser negativo |



#### Atualiza um produto do banco SQL Server

```http
    PUT /api/1/product
```
Body:
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O Id do produto que você quer Atualizar|
| `name`      | `string` | **Obrigatório**. O Nome do produto que você quer |
| `description`      | `string` | **Obrigatório**. A Descrição do produto que você quer |
| `price`      | `number` | **Obrigatório**. O valor não pode ser negativo |

#### Atualiza um produto do banco Mongo DB

```http
    PUT /api/2/product
```
Body:
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `_id`      | `string` | **Obrigatório**. O _Id do produto que você quer Atualizar|
| `name`      | `string` | **Obrigatório**. O Nome do produto que você quer |
| `description`      | `string` | **Obrigatório**. A Descrição do produto que você quer |
| `price`      | `number` | **Obrigatório**. O valor não pode ser negativo |


#### Deleta um produto do banco SQL Server

```http
    DELETE /api/1/product/Get?id=<string>
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do produto que você quer |


#### Deleta um produto do banco MongoDB

```http
    DELETE /api/2/product/Get?id=<string>
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | **Obrigatório**. O id do produto que você quer |
