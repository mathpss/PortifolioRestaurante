using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Context;
using backrestaurante.Entity;

namespace backrestaurante.Services
{
    public class ClienteService : IClienteService
    {
        private readonly RestauranteContext _context;

        public ClienteService(RestauranteContext context)
        {
            _context = context;
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