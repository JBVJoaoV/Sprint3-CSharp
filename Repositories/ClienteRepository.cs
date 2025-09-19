using System;
using System.Collections.Generic;
using System.Linq;
using XpSprint3.Data;
using XpSprint3.Models;

namespace XpSprint3.Repositories
{
    public class ClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository()
        {
            _context = new AppDbContext();
            // Garante que o banco e tabelas sejam criados
            _context.Database.EnsureCreated();
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Clientes.OrderBy(c => c.Id).ToList();
        }

        public Cliente? GetById(int id)
        {
            return _context.Clientes.Find(id);
        }

        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Update(Cliente cliente)
        {
            var existing = _context.Clientes.Find(cliente.Id);
            if (existing == null) return;
            existing.Nome = cliente.Nome;
            existing.Email = cliente.Email;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
