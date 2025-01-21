using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Entity;

namespace backrestaurante.Services
{
    public interface IClienteService
    {
        public Task CriarCliente(Cliente cliente);


        public Task<Cliente> ObterClientePorId(int id);
    }
}