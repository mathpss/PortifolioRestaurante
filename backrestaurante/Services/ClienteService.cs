using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Context;
using backrestaurante.Entity;
using Microsoft.EntityFrameworkCore;
using backrestaurante.Services.Interfaces;

namespace backrestaurante.Services
{
    public class ClienteService : IClienteService
    {
        private readonly RestauranteContext _context;

        public ClienteService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task<Cliente> ClienteLogin(Cliente cliente)
        {
            var clienteBanco = await _context.Clientes.Where(c => c.Nome.ToLower() == cliente.Nome.ToLower() && c.Telefone.ToLower() == cliente.Telefone.ToLower()).FirstOrDefaultAsync();
            return clienteBanco;
        }

        public async Task CriarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }


        public async Task<Cliente> ObterClientePorId(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            return  cliente;
        }
    }
}