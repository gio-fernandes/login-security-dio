# LoginSecurity

Projeto desenvolvido como desafio da DIO para praticar TDD e testes
unitários utilizando .NET.

## Descrição

A aplicação simula um sistema simples de autenticação com controle de
tentativas de login.

## Regras de negócio

-   O usuário deve informar a senha correta para autenticar
-   Cada senha incorreta incrementa o contador de tentativas inválidas
-   Após **3 tentativas inválidas**, o usuário é bloqueado
-   Um usuário bloqueado não consegue mais autenticar
-   Se o usuário acertar a senha antes do bloqueio, o contador de
    tentativas é resetado

## Testes implementados

Foram criados testes unitários utilizando **xUnit** para validar:

-   autenticação com senha correta
-   autenticação com senha incorreta
-   incremento de tentativas inválidas
-   bloqueio após três tentativas
-   impossibilidade de login após bloqueio
-   reset de tentativas após login bem‑sucedido

## Tecnologias utilizadas

-   .NET
-   xUnit
-   C#

## Como executar os testes

No terminal, execute:

dotnet test

## Objetivo do desafio

Aplicar conceitos de **TDD e testes unitários**, garantindo que as
regras de negócio do sistema sejam validadas automaticamente.
