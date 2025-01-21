using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Context;
using backrestaurante.Entity;
using Microsoft.EntityFrameworkCore;

namespace backrestaurante.Services
{
    public class MarmitaService : IMarmitaService
    {
        private readonly RestauranteContext _context;

        public MarmitaService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task CriarMarmita(Marmita marmita)
        {
            _context.Marmitas.Add(marmita);
            await _context.SaveChangesAsync();
        }


        public async Task<Marmita> ObterMarmitaPorId(int id)
        {
            var marmita = await _context.Marmitas.FindAsync(id);

            return  marmita;

        }
    }
}