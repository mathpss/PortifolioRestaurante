using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Context;
using backrestaurante.Entity;
using backrestaurante.Services.Interfaces;


namespace backrestaurante.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly RestauranteContext _context;

        public EnderecoService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task CriarEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task<Endereco> ObterEnderecoPorId(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);

            return  endereco;
        }
    }
}