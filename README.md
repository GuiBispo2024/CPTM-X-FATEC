# Backend CPTM — API de Gestão Ambiental

API RESTful desenvolvida em **ASP.NET Core 8** para gerenciamento de elementos de monitoramento ambiental (efluentes) da CPTM. O projeto segue arquitetura em camadas inspirada em **Clean Architecture**, com separação clara entre domínio, aplicação, infraestrutura e API.

---

## Sumário

- [Visão Geral](#visão-geral)
- [Arquitetura](#arquitetura)
- [Tecnologias](#tecnologias)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Endpoints da API](#endpoints-da-api)
- [Configuração e Execução](#configuração-e-execução)
- [Banco de Dados e Migrations](#banco-de-dados-e-migrations)
- [Autenticação](#autenticação)

---

## Visão Geral

A aplicação expõe uma API para:

- **Cadastro e gestão de Efluentes** — elementos de monitoramento ambiental com mais de 70 campos estruturados (identificação, localização, formulário, regulamentação ambiental, detalhamento, contratos, arquivos e fotos).
- **Gestão de Usuários** — cadastro, atualização, promoção a administrador e exclusão de contas.
- **Autenticação JWT** — login, recuperação e redefinição de senha via e-mail.
- **Domínios (tabelas de referência)** — leitura de tabelas de domínio com cache em memória carregado na inicialização.

---

## Arquitetura

O projeto é dividido em quatro camadas:

```
Backend.Domain          →  Entidades, interfaces de repositório e modelos de domínio
Backend.Application     →  DTOs, serviços, interfaces de serviço, mappers (AutoMapper)
Backend.Infrastructure  →  EF Core + Oracle, repositórios, segurança, e-mail, cache
Backend.API             →  Controllers, middleware, configuração de DI e pipeline HTTP
```

O fluxo padrão de uma requisição é:

```
Controller → Service (Application) → Repository (Infrastructure) → Oracle DB
```

Campos de domínio (listas de opções) são resolvidos em memória via `DominioCacheService`, singleton carregado no startup, evitando consultas repetidas ao banco.

---

## Tecnologias

| Camada | Tecnologia |
|---|---|
| Runtime | .NET 8 |
| ORM | Entity Framework Core 8 |
| Banco de dados | Oracle (Oracle.EntityFrameworkCore 8.23) |
| Autenticação | JWT Bearer (Microsoft.AspNetCore.Authentication.JwtBearer 8) |
| Mapeamento | AutoMapper |
| E-mail | MailKit 4.16 |
| Documentação | Swagger / Swashbuckle 6.6 |
| Hash de senha | Microsoft.Extensions.Identity.Core |

---

## Estrutura do Projeto

```
Backend/
├── Backend.API/
│   ├── Controllers/
│   │   ├── AuthController.cs        # Login, forgot/reset password
│   │   ├── UserController.cs        # CRUD de usuários
│   │   ├── EfluenteController.cs    # CRUD de efluentes
│   │   └── DominioController.cs     # Leitura de domínios
│   ├── Middleware/
│   │   └── ExceptionMiddleware.cs   # Tratamento global de exceções
│   └── Program.cs                   # Bootstrap, DI, JWT, CORS, Swagger
│
├── Backend.Application/
│   ├── DTOs/                        # Requests e Responses por módulo
│   ├── Interfaces/                  # Contratos de serviços
│   ├── Services/                    # Implementações de negócio
│   ├── Mappers/                     # Perfis AutoMapper
│   ├── Helpers/
│   │   └── DominioTableResolver.cs  # Mapeamento nome → tabela de domínio
│   └── Exception/
│       └── NotFoundException.cs
│
├── Backend.Domain/
│   ├── Entities/
│   │   ├── Efluente.cs              # Entidade principal (70+ campos)
│   │   ├── User.cs
│   │   ├── Dominios.cs
│   │   └── PasswordResetToken.cs
│   ├── Interfaces/                  # IPasswordHasher, ITokenService
│   ├── Repositories/                # Interfaces de repositório
│   └── Models/
│       └── EfluenteData.cs          # Value object para criação/atualização
│
└── Backend.Infrastructure/
    ├── Data/
    │   ├── AppDbContext.cs
    │   └── AppDbContextFactory.cs
    ├── Configurations/              # Fluent API (EF Core)
    ├── Repositories/                # Implementações dos repositórios
    ├── Cache/
    │   └── DominioCacheService.cs   # Cache singleton de domínios
    ├── Security/
    │   ├── TokenService.cs          # Geração de JWT
    │   └── PasswordHasherService.cs
    ├── Services/
    │   └── EmailService.cs          # Envio de e-mail via MailKit
    └── Migrations/
```

---

## Endpoints da API

### Autenticação — `/api/auth`

| Método | Rota | Descrição | Auth |
|---|---|---|---|
| POST | `/api/auth/login` | Login, retorna JWT | ❌ |
| POST | `/api/auth/forgot-password` | Envia link de redefinição por e-mail | ❌ |
| POST | `/api/auth/reset-password` | Redefine a senha via token | ❌ |

### Usuários — `/api/users`

| Método | Rota | Descrição | Auth |
|---|---|---|---|
| POST | `/api/users` | Criar conta | ❌ |
| GET | `/api/users` | Listar todos os usuários | ✅ |
| GET | `/api/users/{id}` | Buscar usuário por ID | ✅ |
| GET | `/api/users/me` | Dados do usuário logado | ✅ |
| PUT | `/api/users/me` | Atualizar dados do usuário logado | ✅ |
| PUT | `/api/users/me/password` | Alterar senha | ✅ |
| PATCH | `/api/users/{id}/admin` | Promover/remover admin | ✅ |
| DELETE | `/api/users/{id}` | Deletar usuário (admin) | ✅ |
| DELETE | `/api/users/me` | Deletar própria conta | ✅ |

### Efluentes — `/api/efluente`

| Método | Rota | Descrição | Auth |
|---|---|---|---|
| GET | `/api/efluente` | Listar todos os efluentes | ✅ |
| GET | `/api/efluente/{codigoMeioAmbienteCptm}` | Buscar efluente por código | ✅ |
| POST | `/api/efluente` | Cadastrar efluente | ✅ |
| PUT | `/api/efluente/{codigoMeioAmbienteCptm}` | Atualizar efluente | ✅ |
| DELETE | `/api/efluente/{codigoMeioAmbienteCptm}` | Soft delete de efluente | ✅ |

> Efluentes utilizam **soft delete** — o registro é marcado como `IsDeleted = true` e filtrado automaticamente pelo EF Core via query filter global.

### Domínios — `/api/dominios`

| Método | Rota | Descrição | Auth |
|---|---|---|---|
| GET | `/api/dominios/{dominio}` | Retorna itens de uma tabela de domínio | ❌ |

---

## Configuração e Execução

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Oracle Database (ou Oracle XE local)

### 1. Clonar o repositório

```bash
git clone <url-do-repositorio>
cd Backend
```

### 2. Configurar `appsettings.json`

Edite `Backend.API/appsettings.json` com sua connection string e configurações JWT:

```json
{
  "ConnectionStrings": {
    "OracleDb": "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));User Id=SEU_USER;Password=SUA_SENHA;"
  },
  "Jwt": {
    "Key": "sua-chave-secreta-aqui-minimo-32-chars",
    "Issuer": "Backend.API",
    "Audience": "Backend.API"
  }
}
```

### 3. Aplicar Migrations

```bash
cd Backend.Infrastructure
dotnet ef database update --startup-project ../Backend.API
```

### 4. Executar a API

```bash
cd Backend.API
dotnet run
```

A API estará disponível em `https://localhost:7xxx`. O Swagger UI estará acessível em `/swagger` no ambiente de desenvolvimento.

---

## Banco de Dados e Migrations

As migrations estão em `Backend.Infrastructure/Migrations/` e cobrem:

| Migration | Descrição |
|---|---|
| `InitialCreate` | Tabela de usuários e sequência `SEQ_USERS` |
| `AddPasswordReset` | Tabela de tokens de redefinição de senha |

Para criar uma nova migration:

```bash
dotnet ef migrations add NomeDaMigration \
  --project Backend.Infrastructure \
  --startup-project Backend.API
```

---

## Autenticação

A API usa **JWT Bearer**. Após o login, inclua o token no header de todas as requisições protegidas:

```
Authorization: Bearer <seu_token>
```

O Swagger UI já está configurado para aceitar o token via botão **Authorize**.

Fluxo de recuperação de senha:

1. `POST /api/auth/forgot-password` → envia e-mail com link contendo token
2. `POST /api/auth/reset-password` → valida o token e redefine a senha

## Colaboradores

- Guilherme Bispo
- Danielle Sismon
- Laíne Devesa
- Marcos Palacio