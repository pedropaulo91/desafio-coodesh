![GitHub](https://img.shields.io/github/license/pedropaulo91/desafio-coodesh)
# DotNet Challenge 20200902

## Projetos

- **FitnessFoods.Application** 
Responsável por receber as requisições 
- **FitnessFoods.Domain**
Responsável pela implementação dos modelos 
- **FitnessFoods.Infraestructure.Data**
Responsável pela persistência dos dados 
- **FitnessFoods.Service**
Responsável pela execução da lógica do negócio 
- **FitnessFoods.Shared**
Responsável por fornecer código para reuso 
- **FitnessFoods.Tests**
Responsável pela execução dos testes


## Como Executar
O projeto principal que deve ser executado é o FitnessFoods.Application. Utilizei o SQL Server Express para armazenar os dados dos produtos. Os arquivos do Open Food Facts são gerados a noite, então escolhi o horário de 03:00 para a execução da importação dos arquivos.

A API é protegia por uma API Key que deve ser passada no Header de cada requisição da seguinte forma:

Nome : api_key

Valor: 45d30d2e72314d30a6dbc81d47ba73aa

A tabela abaixo mostra as funcionalidades de cada rota da API:



|Funcionalidade                           |Rota                                                            |Método HTTP |
|-----------------------------------------|----------------------------------------------------------------|------------|
|Obtém os detalhes da API                 |https://localhost:44341/api/fitnessfoods/                       |GET         |
|Lista todos os produtos (30 por página)  |https://localhost:44341/api/fitnessfoods/products               |GET         |
|Lista os produtos especificando a página |https://localhost:44341/api/fitnessfoods/products?page={numero} |GET         |
|Busca um produto pelo seu código         |https://localhost:44341/api/fitnessfoods/products/{codigo}      |GET         |
|Atualiza um produto pelo seu código      |https://localhost:44341/api/fitnessfoods/products/{codigo}      |PUT         |
|Deleta um produto pelo seu código        |https://localhost:44341/api/fitnessfoods/products/{codigo}      |DELETE      |

## Libs Utilizadas
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
 - Microsoft.EntityFrameworkCore.SqlServer
 - Microsoft.EntityFrameworkCore.Tools
- Quartz.Extensions.Hosting
- Swashbuckle.AspNetCore
- X.PagedList.Mvc.Core
- MSTest.TestFramework
- MSTest.TestAdapter
- Microsoft.NET.Test.Sdk
- FakeItEasy
- coverlet.collector

