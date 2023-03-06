# HandsOn.PlanoContas
Projeto laboratório, contruído como desafio de habilidades

## Estrutura
### HandsOn.PlanoContas.Api
 API Rest que pode ser utilizada com Swagger localmente
 
### HandsOn.PlanoContas.Core
 Contém o Domínio, com as regras de negócio

### HandsOn.PlanoContas.Infrastructure
 Abstrai e desacopla a infraestrutura, contém a definição do Banco de Dados e as Injeções de Dependência
 O projeto Utiliza EFCore (Code-First) como ORM

### HandsOn.PlanoContas.Infrastructure.Auth
 Simula um serviço de autenticação, neste caso adicionando uma camada de segurança através de APIKey

### HandsOn.PlanoContas.UnitTests
 Testes unitários (41 casos) que guiaram a codificação das regras de negócio.


## Requisitos para execução do projeto

.NET 6
SQL Server (ou LocalDB)

## Instruções para executar o projeto

* Faça um Git Checkout deste repositório
* Na IDE de sua preferência, abrir o appsettings.json no projeto API e configurar a string de conexao (DefaultConnection)
* Antes de executar os Testes Unitários, dê preferência a realizar um Build.
* As Migrations estão configuradas para rodar automaticamente e realizar o Seed Inicial.
 Caso não haja permissão local para a execução, é possível criar um banco no SQL Server ou LocalDB com as mesmas configurações do appsettings.json
* Utilizar a APIKey para autenticar: 995C5084-CC91-4005-BFC5-EBBC1060DF9C


Enjoy!
