# UsuariosApi

API de gerenciamento de usuários com autenticação e autorização baseada em JWT.

## 🚀 Funcionalidades

- Cadastro de usuários
- Login com geração de token JWT
- Autorização baseada em idade mínima
- Persistência de dados com MySQL
- Integração com Identity para gerenciamento de usuários

## 🛠️ Tecnologias Utilizadas

- .NET 6.0
- ASP.NET Core
- Entity Framework Core
- MySQL
- JWT (JSON Web Tokens)
- AutoMapper
- Identity Framework

## 📋 Pré-requisitos

- .NET 6.0 SDK
- MySQL Server
- Visual Studio 2022 ou VS Code

## 🔧 Configuração do Ambiente

1. Clone o repositório
```bash
git clone [url-do-repositorio]
```

2. Configure a string de conexão no arquivo `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "UsuarioConnection": "sua-string-de-conexao-mysql"
  },
  "SymmetricSecurityKey": "sua-chave-secreta-para-jwt"
}
```

3. Execute as migrações do banco de dados:
```bash
dotnet ef database update
```

## 🏗️ Estrutura do Projeto

```
UsuariosApi/
├── Controllers/
│   ├── UsuarioController.cs
│   └── AcessoController.cs
├── Data/
│   ├── Dtos/
│   │   ├── CreateUsuarioDto.cs
│   │   └── LoginUsuarioDto.cs
│   └── UsuarioDbContext.cs
├── Models/
│   └── Usuario.cs
├── Services/
│   ├── TokenService.cs
│   └── UsuarioService.cs
├── Authorization/
│   ├── IdadeMinima.cs
│   └── IdadeAuthorization.cs
└── Profiles/
    └── UsuarioProfile.cs
```

## 📝 Endpoints

### Usuário
- `POST /usuario/cadastro` - Cadastra um novo usuário
- `POST /usuario/login` - Realiza login e retorna token JWT

### Acesso
- `GET /acesso` - Endpoint protegido que requer idade mínima de 18 anos

## 🔐 Autenticação

A API utiliza JWT para autenticação. Para acessar endpoints protegidos, inclua o token no header da requisição:

```
Authorization: Bearer seu-token-jwt
```

## ⚙️ Configuração de Autorização

O sistema implementa uma política de autorização baseada em idade mínima (18 anos). A verificação é feita através da data de nascimento do usuário.

## 📦 Dependências

- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore
- Pomelo.EntityFrameworkCore.MySql
- AutoMapper

## 🤝 Contribuição

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
