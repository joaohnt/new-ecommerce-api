# Ecommerce API

API de e-commerce em .NET com arquitetura em camadas, MediatR, Entity Framework Core e SQL Server.

## Estrutura

- `Ecommerce.API`: camada HTTP, controllers, configuração da aplicação, Swagger e health check.
- `Ecommerce.Application`: comandos, queries, handlers e DTOs.
- `Ecommerce.Domain`: entidades, enums, contratos de repositório e paginação.
- `Ecommerce.Infrastructure`: `DbContext`, mapeamentos, migrations e implementações de repositório.
- `Ecommerce.Tests`: testes de domínio.

## Tecnologias

- .NET 10
- ASP.NET Core
- Entity Framework Core
- SQL Server
- MediatR
- Swagger / Swashbuckle
- Docker Compose

## Como rodar localmente

Pré-requisitos:

- .NET SDK 10
- Docker

Suba o banco:

```powershell
docker compose up -d sqlserver
```

Rode a API:

```powershell
dotnet run --project Ecommerce.API
```

A connection string local está em [appsettings.json](/G:/ecommerce-api/Ecommerce.API/appsettings.json) e usa `localhost,1433`.

## Como rodar com Docker

Suba API e banco juntos:

```powershell
docker compose up --build
```

Nesse cenário:

- a API sobe no container `api`
- o SQL Server sobe no container `sqlserver`
- a API usa a connection string injetada pelo [compose.yaml](/G:/ecommerce-api/compose.yaml), apontando para `Server=sqlserver,1433`
- as migrations são aplicadas automaticamente no startup

Para parar os containers:

```powershell
docker compose down
```

Para recriar tudo do zero, incluindo volumes:

```powershell
docker compose down -v
docker compose up --build
```

## Endpoints úteis

- Swagger: `http://localhost:8080/swagger`
- Health check: `http://localhost:8080/health`

## Paginação

O endpoint de listagem de pedidos aceita:

- `pageNumber`
- `pageSize`

Exemplo:

```http
GET /api/v1/order?pageNumber=1&pageSize=10
```
