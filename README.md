# HandsOn.PlanoContas
Projeto laboratório, construído como desafio de habilidades

## Estrutura
### HandsOn.PlanoContas.Api
 API Rest que pode ser utilizada com Swagger localmente   
 Contém um controle de versionamento (ex.: /api/v1/planocontas)
 
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

* .NET 6
* SQL Server (ou LocalDB)

## Instruções para executar o projeto

* Faça um Git Checkout deste repositório
* Na IDE de sua preferência, abrir o appsettings.json no projeto API e configurar a string de conexao (DefaultConnection)
* Antes de executar os Testes Unitários, dê preferência a realizar um Build.
* As Migrations estão configuradas para rodar automaticamente e realizar o Seed Inicial.
 Caso não haja permissão local para a execução, é possível criar um banco no SQL Server ou LocalDB com as mesmas configurações do appsettings.json
* Utilizar a APIKey para autenticar: 995C5084-CC91-4005-BFC5-EBBC1060DF9C




As consultas podem ser realizadas com parâmetros 

https://localhost:[port]/api/v1/PlanoContas
Retorna todos os planos do usuário

Filtros
https://localhost:[port]/api/v1/PlanoContas?[search][type][order]

### type: - determina o tipo da busca
* CODE - procura por determinado código
* NAME - realiza a busca pelo nome da conta (pode ser utilizado apenas parte do nome)
* TYPE - busca pelo tipo da conta (Receita ou Despesa)


### search: deve conter o texto (ou parte) a ser encontrado

### order: sugere a ordenação da lista retornada
* NAME - ordena por nome
* CODE - ordena por código
* TYPE - ordena por tipo
* DEFAULT - retorna pela ordem de criação no banco de dados

=> Para ordenar de forma decrescente, apenas adicione o _DESC no final (Ex.: NAME_DESC)



Enjoy!
