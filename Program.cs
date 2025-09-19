using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using XpSprint3.Models;
using XpSprint3.Repositories;

class Program
{
    static void Main(string[] args)
    {
        var repo = new ClienteRepository();
        int opcao;

        do
        {
            Console.WriteLine("\n--- Sistema de Clientes ---");
            Console.WriteLine("1 - Adicionar Cliente");
            Console.WriteLine("2 - Listar Clientes");
            Console.WriteLine("3 - Atualizar Cliente");
            Console.WriteLine("4 - Remover Cliente");
            Console.WriteLine("5 - Exportar para JSON");
            Console.WriteLine("6 - Importar de JSON");
            Console.WriteLine("7 - Exportar para TXT");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out opcao)) { opcao = -1; }

            switch (opcao)
            {
                case 1:
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine() ?? string.Empty;
                    Console.Write("Email: ");
                    string email = Console.ReadLine() ?? string.Empty;
                    repo.Add(new Cliente { Nome = nome, Email = email });
                    Console.WriteLine("Cliente adicionado com sucesso.");
                    break;

                case 2:
                    var lista = repo.GetAll();
                    Console.WriteLine("\n--- Lista de Clientes ---");
                    foreach (var c in lista)
                    {
                        Console.WriteLine($"ID: {c.Id} | Nome: {c.Nome} | Email: {c.Email}");
                    }
                    break;

                case 3:
                    Console.Write("ID do cliente para atualizar: ");
                    if (int.TryParse(Console.ReadLine(), out int idUpdate))
                    {
                        var existente = repo.GetById(idUpdate);
                        if (existente == null)
                        {
                            Console.WriteLine("Cliente não encontrado.");
                        }
                        else
                        {
                            Console.Write($"Novo nome (enter para manter '{existente.Nome}'): ");
                            string novoNome = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(novoNome)) novoNome = existente.Nome;
                            Console.Write($"Novo email (enter para manter '{existente.Email}'): ");
                            string novoEmail = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(novoEmail)) novoEmail = existente.Email;
                            repo.Update(new Cliente { Id = idUpdate, Nome = novoNome, Email = novoEmail });
                            Console.WriteLine("Cliente atualizado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;

                case 4:
                    Console.Write("ID do cliente para remover: ");
                    if (int.TryParse(Console.ReadLine(), out int idDelete))
                    {
                        repo.Delete(idDelete);
                        Console.WriteLine("Cliente removido (se existia).");
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;

                case 5:
                    ExportToJson(repo);
                    break;

                case 6:
                    ImportFromJson(repo);
                    break;

                case 7:
                    ExportToTxt(repo);
                    break;

                case 0:
                    Console.WriteLine("Saindo..."); break;

                default:
                    Console.WriteLine("Opção inválida."); break;
            }
        } while (opcao != 0);
    }

    static void ExportToJson(ClienteRepository repo)
    {
        var lista = repo.GetAll();
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(lista, options);
        var path = Path.Combine(Directory.GetCurrentDirectory(), "clientes.json");
        File.WriteAllText(path, json);
        Console.WriteLine($"Exportado {lista?.AsList()?.Count ?? 0} clientes para {path}");
    }

    static void ImportFromJson(ClienteRepository repo)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "clientes.json");
        if (!File.Exists(path))
        {
            Console.WriteLine("Arquivo clientes.json não encontrado na pasta do projeto.");
            return;
        }
        var json = File.ReadAllText(path);
        try
        {
            var lista = JsonSerializer.Deserialize<List<Cliente>>(json);
            if (lista == null) { Console.WriteLine("Nenhum cliente encontrado no JSON."); return; }
            foreach (var c in lista)
            {
                // Se ID existir, atualiza; senão adiciona (removendo ID para permitir autoincremento)
                var existing = c.Id > 0 ? repo.GetById(c.Id) : null;
                if (existing != null)
                {
                    repo.Update(new Cliente { Id = existing.Id, Nome = c.Nome, Email = c.Email });
                }
                else
                {
                    repo.Add(new Cliente { Nome = c.Nome, Email = c.Email });
                }
            }
            Console.WriteLine($"Importação concluída. Processados: {lista.Count} clientes.");                
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao importar JSON: " + ex.Message);
        }
    }

    static void ExportToTxt(ClienteRepository repo)
    {
        var lista = repo.GetAll();
        var path = Path.Combine(Directory.GetCurrentDirectory(), "clientes.txt");
        using var sw = new StreamWriter(path);
        foreach (var c in lista)
        {
            sw.WriteLine($"{c.Id};{c.Nome};{c.Email}");
        }
        Console.WriteLine($"Exportado {lista?.AsList()?.Count ?? 0} clientes para {path}");
    }
}

// Helper extension for IEnumerable to get List easily without adding LINQ in Program
static class EnumerableExtensions
{
    public static System.Collections.Generic.List<T> AsList<T>(this System.Collections.Generic.IEnumerable<T> source)
    {
        return source == null ? new System.Collections.Generic.List<T>() : new System.Collections.Generic.List<T>(source);
    }
}
