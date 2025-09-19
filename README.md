# XpSprint3 - Sistema de Clientes (C# Console)

Projeto refatorado para atender aos requisitos da entrega:
- Estruturação de classes (Models, Data, Repositories)
- Manipulação de banco SQLite (CRUD completo via Entity Framework Core)
- Interface Console simples
- Arquivo de banco `clientes.db` é criado automaticamente na pasta do projeto

## Como rodar

1. Abra um terminal na pasta do projeto (a que contém o `.csproj`).
2. Execute `dotnet restore` para baixar dependências (inclui EF Core SQLite).
3. Execute `dotnet run` para compilar e executar a aplicação.

## Observações

- Se quiser abrir o banco SQLite manualmente, use qualquer visualizador de SQLite apontando para `clientes.db` na pasta do projeto.
- Para exportar/importar via JSON ou TXT, podemos adicionar comandos extras (posso gerar esse código também).
