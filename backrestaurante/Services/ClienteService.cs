using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Context;
using backrestaurante.Entity;
using Microsoft.EntityFrameworkCore;
using backrestaurante.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace backrestaurante.Services
{
    public class ClienteService : IClienteService
    {
        private readonly RestauranteContext _context;
        private readonly IConfiguration Configuration;

        public ClienteService(RestauranteContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
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

        public string GerarTokenJwt(Cliente cliente)
        {               
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("JwtOptions:SecurityKey").Value));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim("Nome", cliente.Nome),
                new Claim("Telefone", cliente.Telefone),
                new Claim(ClaimTypes.Role, cliente.Perfil.ToString())
            };
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}