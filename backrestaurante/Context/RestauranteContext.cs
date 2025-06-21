using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Entity;
using backrestaurante.Models;
using Microsoft.EntityFrameworkCore;

namespace backrestaurante.Context
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options) { }


        public DbSet<Cardapio> Cardapios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Marmita> Marmitas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    Id = 1,
                    Nome = "Cheff",
                    Telefone = "Restaurante",
                    Perfil = Perfil.Adm

                }
            );

        }
    }
}