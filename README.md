# Login Security DIO

[![.NET Tests](https://github.com/gio-fernandes/login-security-dio/actions/workflows/dotnet-tests.yml/badge.svg?branch=main)](https://github.com/gio-fernandes/login-security-dio/actions/workflows/dotnet-tests.yml)
[![Coverage](https://img.shields.io/badge/Coverage-HTML%20Report-blue)](#cobertura-de-testes)
[![.NET](https://img.shields.io/badge/.NET-10.0-purple)](#tecnologias-utilizadas)
[![xUnit](https://img.shields.io/badge/Tests-xUnit-5C2D91)](#estratégia-de-testes)

Projeto desenvolvido para simular um sistema de autenticação simples com foco em **qualidade de software**, **testes unitários** e **integração contínua**.

O sistema valida autenticação por senha, controla tentativas inválidas, bloqueia o usuário após múltiplas falhas e reinicia o contador quando a autenticação é bem-sucedida.

---

## Sumário

- [Objetivo](#objetivo)
- [Regras de negócio](#regras-de-negócio)
- [Tecnologias utilizadas](#tecnologias-utilizadas)
- [Estrutura do projeto](#estrutura-do-projeto)
- [Estratégia de testes](#estratégia-de-testes)
- [Cobertura de testes](#cobertura-de-testes)
- [Integração contínua](#integração-contínua)
- [Como executar o projeto](#como-executar-o-projeto)
- [Como executar os testes](#como-executar-os-testes)
- [Como gerar o relatório de cobertura](#como-gerar-o-relatório-de-cobertura)
- [Aprendizados aplicados](#aprendizados-aplicados)
- [Possíveis melhorias futuras](#possíveis-melhorias-futuras)
- [Autora](#autora)

---

## Objetivo

Este projeto foi criado para praticar:

- modelagem de regra de negócio
- testes unitários com xUnit
- testes parametrizados com `Theory` e `InlineData`
- organização de testes por responsabilidade
- geração de cobertura de testes
- pipeline automática com GitHub Actions

---

## Regras de negócio

O sistema segue as seguintes regras:

- o usuário deve informar a senha correta para autenticar
- cada senha incorreta incrementa o contador de tentativas inválidas
- após **3 tentativas inválidas**, o usuário é bloqueado
- um usuário bloqueado não consegue mais autenticar, mesmo com a senha correta
- ao acertar a senha antes do bloqueio, o contador de tentativas é resetado

---

## Tecnologias utilizadas

- **C#**
- **.NET 10**
- **xUnit**
- **Coverlet**
- **ReportGenerator**
- **GitHub Actions**
- **Git e GitHub**

---

## Estrutura do projeto

```bash
login-security-dio/
├── .github/
│   └── workflows/
│       └── dotnet-tests.yml
├── LoginSecurity/
│   ├── Models/
│   │   └── LoginService.cs
│   ├── Program.cs
│   └── LoginSecurity.csproj
├── LoginSecurity.Tests/
│   ├── AuthenticationTests.cs
│   ├── BlockingTests.cs
│   ├── ValidationTests.cs
│   └── LoginSecurity.Tests.csproj
├── LoginSecurity.sln
├── README.md
└── .gitignore
```

---

## Estratégia de testes

Os testes foram organizados por responsabilidade para facilitar leitura e manutenção:

### `AuthenticationTests`
Valida cenários relacionados à autenticação:

- login com senha correta
- login com senha incorreta
- reset do contador após sucesso
- autenticação bem-sucedida após tentativas inválidas

### `BlockingTests`
Valida cenários relacionados ao bloqueio:

- incremento de tentativas inválidas
- bloqueio após 3 tentativas incorretas
- usuário bloqueado não autentica
- tentativas não continuam aumentando após bloqueio

### `ValidationTests`
Valida cenários de entrada e testes parametrizados:

- senha vazia
- senha nula
- múltiplas senhas inválidas com `Theory` + `InlineData`

---

## Cobertura de testes

O projeto utiliza **Coverlet** para coleta de cobertura e **ReportGenerator** para gerar relatório HTML.

O badge de cobertura acima aponta para esta seção porque o relatório é gerado localmente.  
Quando quiser, dá para evoluir isso para uma cobertura automática publicada por pipeline.

### Comandos usados

```bash
dotnet test --collect:"XPlat Code Coverage"
reportgenerator -reports:**/coverage.cobertura.xml -targetdir:coveragereport -reporttypes:Html
```

Após a geração, abra localmente:

```bash
coveragereport/index.html
```

---

## Integração contínua

Foi configurada uma pipeline no **GitHub Actions** para executar automaticamente:

- restore
- build
- testes unitários

A pipeline é acionada a cada `push` e `pull request` na branch principal.

Arquivo do workflow:

```bash
.github/workflows/dotnet-tests.yml
```

---

## Como executar o projeto

Na raiz da solução, rode:

```bash
dotnet restore
dotnet build
dotnet run --project LoginSecurity
```

---

## Como executar os testes

```bash
dotnet test
```

---

## Como gerar o relatório de cobertura

### 1. Coletar cobertura
```bash
dotnet test --collect:"XPlat Code Coverage"
```

### 2. Gerar relatório HTML
```bash
reportgenerator -reports:**/coverage.cobertura.xml -targetdir:coveragereport -reporttypes:Html
```

### 3. Abrir o relatório
Abra o arquivo:

```bash
coveragereport/index.html
```

---

## Aprendizados aplicados

Neste projeto foram praticados conceitos importantes de desenvolvimento e QA, como:

- validação de regra de negócio com testes unitários
- cobertura de cenários positivos, negativos e de borda
- refatoração para reduzir repetição nos testes
- organização de testes por responsabilidade
- resolução de conflitos de merge no Git
- configuração de CI com GitHub Actions
- geração de relatório de cobertura de testes

---

## Possíveis melhorias futuras

- adicionar badge de cobertura automatizada por pipeline
- publicar relatório de cobertura automaticamente
- adicionar mais cenários de borda
- incluir lint/análise estática no workflow
- expandir o sistema para múltiplos usuários
- utilizar armazenamento seguro de credenciais

---

## Autora

Projeto desenvolvido por **Giovanna Fernandes** como parte dos estudos em QA, automação de testes e boas práticas de desenvolvimento.

GitHub: [gio-fernandes](https://github.com/gio-fernandes)
