using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Dtos;
using backrestaurante.Entity;

namespace backrestaurante.Services.Interfaces
{
    public interface IClienteService
    {
        public Task CriarCliente(Cliente cliente);


        public Task<Cliente> ObterClientePorId(int id);

        public Task<Cliente> ClienteLogin(Cliente cliente);

        public string GerarTokenJwt(Cliente cliente);
    }
}