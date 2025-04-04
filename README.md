# FilmesApi 🎬

API REST construída com ASP.NET Core para gerenciamento de filmes.

## 📦 Estrutura do Projeto

- `Program.cs`: configuração principal da aplicação ASP.NET Core
- `FilmesApi.csproj` e `FilmesApi.sln`: arquivos do projeto e solução
- `FilmeContext.cs`: DbContext configurado com EF Core
- `Models/Filme.cs`: modelo de domínio `Filme`
- `DTOs`:
  - `CreateFilmeDto.cs`: DTO para criação de filmes
  - `UpdateFilmeDto.cs`: DTO para atualização de filmes
- `Profiles/FilmeProfile.cs`: perfil do AutoMapper para mapear entre DTO e modelo
- `Migrations/`: arquivos de migração gerados pelo Entity Framework Core
- `appsettings.json`: configuração da connection string e ambiente
- `FilmesApi.http`: arquivo de testes de endpoints via VS Code

## 📚 Funcionalidades Implementadas

- ✅ Criação da estrutura base do projeto
- ✅ Modelo de dados para filmes
- ✅ DTOs para criação e atualização
- ✅ AutoMapper para conversão entre modelos e DTOs
- ✅ Configuração do EF Core com suporte a migrações
- ✅ Primeira migração: criação da tabela `Filmes`

## 🚀 Para executar o projeto

1. Configure o SQL Server e defina sua connection string no `appsettings.json`
2. Rode as migrações:
   ```bash
   dotnet ef database update
   dotnet run
Teste a API com ferramentas como Postman ou FilmesApi.http

Criado com 💻 por [Sávio Fagundes](https://github.com/SavioFagundes)
