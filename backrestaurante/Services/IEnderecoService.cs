using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Entity;
using backrestaurante.Models;

namespace backrestaurante.Services
{
    public interface IEnderecoService
    {
        public Task CriarEndereco(Endereco endereco);

        public Task<Endereco> ObterEnderecoPorId(int id);
    }
}