using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Entity;
using Microsoft.EntityFrameworkCore;

namespace backrestaurante.Context
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext>  options) : base(options){}


        public DbSet<Cliente>Clientes { get; set; }

        public DbSet<Marmita>Marmitas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }


    }
}