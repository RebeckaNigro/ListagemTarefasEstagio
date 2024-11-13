# Descrição
Este é um projeto de uma aplicação web para o gerenciamento de tarefas. A aplicação permite aos usuários criar, editar, excluir e listar tarefas, com funcionalidades de busca e filtragem. O backend foi desenvolvido em C# com ASP.NET, enquanto o frontend utiliza HTML, CSS e JavaScript para uma interface dinâmica. Este projeto faz parte de um processo seletivo para a vaga de estágio na StartUp SESI.

## Tecnologias Utilizadas
- **Frontend**:
  - **HTML5** e **CSS3** para estruturação e estilização.
  - **JavaScript** para manipulação do DOM e integração com a API.
  - **Bootstrap** para um design responsivo e componentes modernos.
  
- **Backend**:
  - **C# com ASP.NET** para desenvolvimento de uma API RESTful.
  - **Entity Framework Core** para integração com o banco de dados.
  - **PostgreSQL** como banco de dados relacional.
  - **Visual Studio 2022** para desenvolvimento.
  
## Estrutura do Projeto

Abaixo está a estrutura de diretórios do projeto, para facilitar a navegação:

```
Lista-de-Tarefas
├── frontend
│   ├── css
│   │   ├── index.css
│   │   └── style.css
│   ├── img
│   │   ├── atividades.png
│   ├── js
│   │   ├── editaRegistro.js
│   │   ├── listarTarefas.js
│   │   ├── script.js
│   │   └── tarefas.js
│   ├── editaRegistro.html
│   ├── index.html
│   ├── listarTarefas.html
│   ├── menuTarefas.html
│   └── tarefas.html
├── backend
│   ├── Controllers
│   │   └── TarefasController.cs
│   │   └── UsuarioController.cs
│   ├── Data
│   │   └── SistemadeTarefasDBContext.cs
├── Enums
│   └── StatusDaTarefa.cs
├── Migrations
│   └── [Migrações serão geradas aqui]
├── Models
│   ├── TarefaModel.cs
│   ├── UsuarioModel.cs
├── Repository
│   ├── ITarefaRepository.cs
│   ├── TarefaRepository.cs
│   ├── IUsuarioRepository.cs
│   └── UsuarioRepository.cs
├── Program.cs
└── appsettings.json
└── README.md
```

## Tecnologias Utilizadas
- **Frontend**:
  - HTML5 e CSS3 para a estrutura e estilização das páginas.
  - JavaScript para a manipulação de DOM e integração com a API.
  - Bootstrap para componentes responsivos e design moderno.
  
- **Backend**:
  - C# com ASP.NET para criação de API RESTful.
  - Entity Framework Core para integração com o banco de dados.
  - PostgreSQL como banco de dados relacional.
  - Visual Studio 2022 para desenvolvimento.

## Funcionalidades

### Usuário:
- **Cadastro de usuário**: Registro de novos usuários.
- **Login e autenticação**: Validação de usuário para acessar o sistema.

### Tarefas:
- **Criação de Tarefa**: Adição de novas tarefas com título e descrição.
- **Edição de Tarefa**: Atualização de informações das tarefas.
- **Exclusão de Tarefa**: Remoção de tarefas.
- **Listagem e Pesquisa**: Visualização e busca de tarefas por título ou descrição.

## Interface do Usuário
As principais telas da aplicação são:
- **Tela de Login**: Autenticação de usuário para acesso.
- **Tela de Menu**: Acesso rápido às funcionalidades (criar, listar, editar, excluir tarefas).
- **Tela de Listagem**: Visualização e pesquisa de tarefas registradas.
- **Tela de Edição**: Formulário para editar tarefas existentes.
- **Tela de Criação**: Formulário para criar novas tarefas.

## Como Executar o Projeto

### Pré-requisitos
- **.NET 6 SDK**.
- **Node.js** e **npm** para executar o frontend (opcional).
- **PgAdmin** para o banco de dados PostgreSQL.

### Configuração do Backend
1. Clone o repositório:
   ```bash
   git clone https://github.com/RebeckaNigro/ListagemTarefasEstagio.git
   cd ListagemTarefasEstagio
   ```

2. Configure a string de conexão no arquivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DataBase": "Host=localhost;Port=8080;Database=PROJETO_ESTAGIO;User Id=postgres;Password=supervisor"
   }
   ```

3. Execute as migrações do banco de dados:
   - Abra o Console do Gerenciador de Pacotes e execute:
     ```bash
     Add-Migration InitialDB -Context SistemadeTarefasDBContext
     Update-Database -Context SistemadeTarefasDBContext
     ```

4. Execute o backend:
   ```bash
   dotnet run
   ```

### Acesso à API
A API pode também ser acessada por meio do seguinte link:
[https://listagemtarefasestagio.azurewebsites.net](https://listagemtarefasestagio.azurewebsites.net)

## Endpoints da API
| Método | Endpoint            | Descrição                           |
|--------|---------------------|-------------------------------------|
| GET    | /api/tarefa         | Retorna todas as tarefas            |
| GET    | /api/tarefa/{id}    | Retorna uma tarefa específica       |
| POST   | /api/tarefa         | Cria uma nova tarefa                |
| PUT    | /api/tarefa/{id}    | Atualiza uma tarefa existente       |
| DELETE | /api/tarefa/{id}    | Exclui uma tarefa existente         |
| GET    | /api/usuario        | Retorna todos os usuários           |
| GET    | /api/usuario/{id}   | Retorna um usuário específico       |
| POST   | /api/usuario        | Cria um novo usuário                |
| PUT    | /api/usuario/{id}   | Atualiza um usuário existente       |
| DELETE | /api/usuario/{id}   | Exclui um usuário existente         |

## Banco de Dados
### A estrutura da tabela de tarefas:
```sql
-- Database: PROJETO_ESTAGIO

-- DROP DATABASE IF EXISTS "PROJETO_ESTAGIO";

CREATE DATABASE "PROJETO_ESTAGIO" 
    WITH OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Portuguese_Brazil.1252'
    LC_CTYPE = 'Portuguese_Brazil.1252'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
```

Para gerar as tabelas de forma automatizada, acesse o Console do Gerenciador de Pacotes e execute:

```bash
Add-Migration InitialDB -Context SistemadeTarefasDBContext
Update-Database -Context SistemadeTarefasDBContext
```

## Pacotes Utilizados
- `Microsoft.EntityFrameworkCore`
- `Npgsql.EntityFrameworkCore.PostgreSQL`
- `Microsoft.EntityFrameworkCore.Design`

## Explicação das Pastas
- **Data/ApplicationDbContext.cs**: Define o contexto do banco de dados usando o Entity Framework Core.
- **Enums/StatusTarefa.cs**: Enum para representar o status das tarefas.
- **Models/Tarefa.cs**: Modelo de entidade para representar uma tarefa no banco de dados.
- **Repository/ITarefaRepository.cs**: Interface para o repositório de tarefas.
- **Repository/TarefaRepository.cs**: Implementação do repositório de tarefas com operações CRUD.

## Referências
- [ASP.NET Core Documentation](https://learn.microsoft.com/aspnet/core)
- [Entity Framework Core Documentation](https://learn.microsoft.com/ef/core)
- [Bootstrap Documentation](https://getbootstrap.com/docs)
- **Ícone de Atividades** por [GOWI] em [Flaticon](https://www.flaticon.com/br/icone-gratis/atividades_2686222).

## Autor
Desenvolvido por **Rebecka de Lima Nigro**.
