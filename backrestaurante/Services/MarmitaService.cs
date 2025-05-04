using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Context;
using backrestaurante.Entity;
using Microsoft.EntityFrameworkCore;
using backrestaurante.Services.Interfaces;
using backrestaurante.Dtos;
using backrestaurante.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace backrestaurante.Services
{
    public class MarmitaService : IMarmitaService
    {
        private readonly RestauranteContext _context;
        public MarmitaService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task<Marmita> ObterMarmitaPorId(int id)
        {
            var marmita = await _context.Marmitas.FindAsync(id);

            return marmita;
        }

        public async Task CriarMarmita(Marmita marmita)
        {
            _context.Marmitas.Add(marmita);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> ListaEntregaHoje()
        {
            var query =  _context.Clientes
                .Include(m => m.Marmitas.Where(r => r.RetiradaEntrega == RetiradaEnum.Entrega
                && r.Data.Date == DateTime.Today))
                .Include(e => e.Enderecos)
                .Where(m => m.Marmitas.Any());

            
               
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> ListaEntrega()
        {
            var query = _context.Clientes
                .Include(m => m.Marmitas.Where(r => r.RetiradaEntrega == RetiradaEnum.Entrega))
                .Include(e => e.Enderecos)
                .Where(m => m.Marmitas.Any());
                
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> ListaRetirada()
        {
            var query =  _context.Clientes
                .Include(m => m.Marmitas.Where(r => r.RetiradaEntrega == RetiradaEnum.Retirada))
                .Where(m => m.Marmitas.Any());
                

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> ListaRetiradaHoje()
        {
            var query = _context.Clientes
                .Include(m => m.Marmitas.Where(r => r.RetiradaEntrega == RetiradaEnum.Retirada && r.Data.Date == DateTime.Today))                
                .Where(m => m.Marmitas.Any());

            return await query.ToListAsync();
        }
    }
}