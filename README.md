# 🧾 XpSprint3 — Sistema de Clientes (C# Console)

## 🎯 Objetivo
Aplicação console em C# para gerenciar clientes com persistência local (SQLite).  
Esta versão foi preparada para entrega da disciplina e inclui: estrutura organizada, CRUD com EF Core + SQLite, import/export (JSON/TXT) e diagrama de classes.

---

## ⚙️ Tecnologias utilizadas
- .NET 8.0
- C# (Programação orientada a objetos)
- Entity Framework Core (SQLite)
- SQLite (arquivo local `clientes.db`)
- Ferramentas: `dotnet CLI`, editor/IDE (VS Code / Visual Studio)

---

## 📂 Estrutura do projeto
```
XpSprint3/
├── bin/
│   └── Debug/
│      └── net8.0/
│         └── clientes.db                  # (gerado automaticamente)
│         └── clientes.json                # (gerado ao exportar)
│         └── clientes.txt                 # (gerado ao exportar)
├── Data/
│   └── AppDbContext.cs          # DbContext (SQLite)
├── Models/
│   └── Cliente.cs               # Modelo de domínio (Cliente)
├── Repositories/
│   └── ClienteRepository.cs     # CRUD (Repository Pattern)
├── Program.cs                   # Interface Console + import/export
├── diagrama.png                 # Diagrama em PNG (gerado)
├── README.md                    # Este arquivo
└── XpSprint3.csproj
```

---

## 🧭 Funcionalidades principais
- CRUD completo sobre `Cliente` (Id, Nome, Email) usando EF Core + SQLite.
- Exportar clientes para `clientes.json` (JSON formatado).
- Importar clientes de `clientes.json` (atualiza por Id ou adiciona novo).
- Exportar clientes para `clientes.txt` (formato `Id;Nome;Email`).
- Banco `clientes.db` criado automaticamente ao iniciar a aplicação.

---

## ▶️ Como executar (passo a passo)
1. Abra o terminal na pasta do projeto (onde está `XpSprint3.csproj`).
2. Restaure dependências:
   ```bash
   dotnet restore
   ```
3. Rode a aplicação:
   ```bash
   dotnet run
   ```
4. Use o menu apresentado no console:
   - `1` Adicionar Cliente
   - `2` Listar Clientes
   - `3` Atualizar Cliente
   - `4` Remover Cliente
   - `5` Exportar para JSON (`clientes.json`)
   - `6` Importar de JSON (`clientes.json`)
   - `7` Exportar para TXT (`clientes.txt`)
   - `0` Sair

---

## 🗃️ Sobre o banco de dados
- O projeto usa SQLite; o arquivo `clientes.db` será criado no diretório do projeto automaticamente.
- Para visualizar ou editar o banco manualmente, use um visualizador de SQLite (DB Browser for SQLite, SQLiteStudio, etc).

---

## 🔁 Import / Export
- **Exportar JSON**: gera `clientes.json` com lista completa dos clientes (formato legível).
- **Importar JSON**: se o `Id` do cliente existir, o registro será atualizado; caso contrário, será adicionado (autoincrement).
- **Exportar TXT**: gera `clientes.txt` com linhas no formato `Id;Nome;Email`.

---

## 🧩 Diagrama de arquitetura
- Arquivo PlantUML: `diagrama.puml`
- PNG gerado: `diagrama.png` (incluso no repositório)

---

##   👨‍💻 Integrantes do Projeto

- João Pedro de Souza Vieira Rm: 99805
- Gabriel Riqueto Reis Rm: 98685
- Gabriel Oliveira Rodrigues Rm: 98565
- Leonardo Nicastro Mansur Castillo Rm: 551659

