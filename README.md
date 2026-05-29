# ProductsAPI — API RESTful com .NET

> API de gerenciamento de produtos desenvolvida em **C# com .NET 8**, aplicando boas práticas de engenharia de software: arquitetura em camadas, princípios SOLID, Clean Code e separação explícita de responsabilidades.

---

## Arquitetura

O projeto adota uma **arquitetura em camadas (Layered Architecture)**, com separação clara de responsabilidades entre cada nível da aplicação:

```
ProductsAPI/
├── Entities/          # Modelos de domínio — representam as tabelas/entidades do banco
├── Dtos/             # Data Transfer Objects — contratos de entrada e saída da API
├── Mappers/          # Mapeamento entre Entity <-> DTO (sem frameworks externos, manual e explícito)
├── Repositories/      # Camada de acesso a dados — abstração sobre o ORM (EF Core)
├── Services/         # Camada de negócio — orquestra regras, validações e fluxos
├── Controllers/      # Camada de apresentação — expõe os endpoints HTTP REST
├── Exceptions/      # Exceções de domínio customizadas e middleware de tratamento global
├── Auth/            # Autenticação e autorização (JWT)
└── Config/          # Configurações da aplicação (DI, Swagger, CORS, etc.)
```

Essa estrutura espelha padrões amplamente adotados em ecossistemas como **Spring Boot (Java)**, garantindo familiaridade e baixo acoplamento entre camadas.

---

## Princípios Aplicados

### SOLID
| Princípio | Aplicação |
|-----------|-----------|
| **S** — Single Responsibility | Cada classe tem uma única razão para mudar: `Service` cuida de negócio, `Repository` cuida de dados, `Controller` cuida de HTTP |
| **O** — Open/Closed | Interfaces definem contratos; novas implementações não alteram código existente |
| **L** — Liskov Substitution | Implementações concretas são intercambiáveis por suas interfaces (ex: `IProductRepository`) |
| **I** — Interface Segregation | Interfaces coesas e específicas por domínio, sem métodos desnecessários |
| **D** — Dependency Inversion | Controllers dependem de interfaces de `Service`; Services dependem de interfaces de `Repository` — nunca de implementações concretas |

### Clean Code
- Nomes expressivos para classes, métodos e variáveis
- Métodos pequenos e com propósito único
- Ausência de comentários redundantes (o código se documenta)
- Consistência e previsibilidade em toda a base de código

---

## Stack Técnica

| Tecnologia | Versão | Papel |
|------------|--------|-------|
| **C#** | 12 | Linguagem principal |
| **.NET** | 8 (LTS) | Runtime e framework web (ASP.NET Core) |
| **ASP.NET Core** | 8 | Web framework — equivalente ao Spring MVC |
| **Entity Framework Core** | 8 | ORM — equivalente ao Spring Data JPA / Hibernate |
| **SQLite** | — | Banco de dados (desenvolvimento local) |
| **Swagger / Scalar** | — | Documentação interativa da API |

---


## Como Executar

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio Code](https://code.visualstudio.com/) com a extensão **C# Dev Kit**

### Rodando localmente

```bash
# Restaurar dependências
dotnet restore

# Aplicar migrations e criar o banco
dotnet ef database update

# Rodar a API
dotnet run --project ProductsAPI
```

A API estará disponível em `http://localhost:5000`.  
A documentação Swagger estará em `http://localhost:5000/swagger`.

---

## Status do Projeto

Em desenvolvimento ativo — construído incrementalmente com commits atômicos por feature/camada.

---

## Autor

Desenvolvido por `pr0mesy`