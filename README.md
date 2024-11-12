## *Projeto de Listagem de Tarefas de Estágio*

## Descrição
Este repositório contém um projeto em C# desenvolvido para gerenciar tarefas em um ambiente de estágio. Ele inclui funcionalidades para listar, criar, atualizar e deletar tarefas, bem como gerenciar usuários associados às tarefas.

## Funcionalidades
- CRUD de tarefas e usuários.
- Relacionamento entre usuários e tarefas.
- Mapeamento de status das tarefas.
- Persistência de dados com Entity Framework Core.

## Estrutura do Projeto
- **Controllers**: Contém controladores para gerenciar rotas e endpoints da aplicação.
- **Models**: Define as entidades `Tarefa` e `Usuário`.
- **Repository**: Implementa a lógica de acesso a dados e interfaces.
- **Data**: Configuração do contexto do banco de dados e mapeamentos.
- **Enums**: Definições de status de tarefa.
- **Migrations**: Scripts para controle de versão do banco de dados.

## Como Executar
1. Clone este repositório.
2. Configure a string de conexão no `appsettings.json`.
3. Execute `dotnet run` para iniciar o projeto.

## Pré-requisitos
- .NET SDK 6.0 ou superior.
- Entity Framework Core.

## Autor
Desenvolvido por Rebecka Nigro Lima.
