# GreatSchool API

Uma API REST para gerenciar informações de uma escola, como alunos, professores e turmas.

## Tecnologias Utilizadas

*   .NET 10.0
*   ASP.NET Core
*   Entity Framework Core
*   SQL Server

## Pré-requisitos

*   [.NET 10.0 SDK](https://dotnet.microsoft.com/download) instalado.
*   Um servidor SQL Server (local ou remoto) acessível.
*   Uma connection string válida no arquivo `appsettings.json`.

## Como Executar o Projeto

1.  Clone o repositório:
    ```bash
    git clone <URL_DO_SEU_REPOSITORIO>
    ```
2.  Navegue até o diretório do projeto:
    ```bash
    cd GreatSchool.API
    ```
3.  Restaure as dependências:
    ```bash
    dotnet restore
    ```
4.  Compile o projeto:
    ```bash
    dotnet build
    ```
5.  Execute a aplicação (dentro da pasta `GreatSchool.API`):
    ```bash
    cd GreatSchool.API
    dotnet run
    ```
    A API estará disponível em `http://localhost:5000` ou `https://localhost:5001` (verifique o arquivo `launchSettings.json`).

## Executando as Migrations do Entity Framework Core

As migrations são usadas para criar e atualizar o banco de dados com base nos seus `Models`.

### 1. Criando uma nova Migration

Quando você fizer alterações nos seus modelos (nas classes dentro da pasta `Models`), você precisará criar uma nova migration para refletir essas mudanças no banco de dados.

Execute o comando a seguir na raiz do projeto (na pasta `GreatSchool.API` que contém o arquivo `.sln`):

```bash
dotnet ef migrations add <NomeDaSuaMigration> --project GreatSchool.API
```

*   Substitua `<NomeDaSuaMigration>` por um nome descritivo para a sua migration (ex: `AdicionaCampoDataNascimentoAluno`).
*   O comando `--project GreatSchool.API` especifica qual projeto contém o `DbContext`.

Isso criará um novo arquivo de migration na pasta `GreatSchool.API/Migrations`.

### 2. Aplicando a Migration no Banco de Dados

Depois de criar a migration, você precisa aplicá-la ao banco de dados para que as tabelas sejam criadas ou atualizadas.

Execute o seguinte comando na raiz do projeto:

```bash
dotnet ef database update --project GreatSchool.API
```

Este comando executará todas as migrations pendentes e atualizará o schema do seu banco de dados para corresponder aos seus modelos atuais.

**Importante:** Certifique-se de que a sua string de conexão no `appsettings.Development.json` ou `appsettings.json` está configurada corretamente antes de executar o comando `database update`.
