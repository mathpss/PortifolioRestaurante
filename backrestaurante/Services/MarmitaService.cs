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

            return  marmita;
        }

        public async Task CriarMarmita(Marmita marmita)
        {
            _context.Marmitas.Add(marmita);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MarmitaRetiradaDto>> MarmitaRetirada(int idMarmita, int idCliente)
        {
            var clientes = await _context.Clientes.Where(c => c.Id == idCliente).ToListAsync();
            var marmitas = await _context.Marmitas.Where(m => m.Id == idMarmita && m.RetiradaEntrega == RetiradaEnum.Retirada).ToListAsync();
             
            var query = from marmita in marmitas
                        join cliente in clientes
                        on marmita.ClienteId equals cliente.Id
                        select new MarmitaRetiradaDto { Nome = cliente.Nome, Telefone = cliente.Telefone, Misturas = marmita.Misturas, Guarnicoes = marmita.Guarnicoes, Tamanho = marmita.Tamanho, Data = marmita.Data, };

            return query;            
        }

        public async Task<IEnumerable<MarmitaRetiradaDto>> MarmitaEntrega(int idMarmita, int idCliente)
        {
            var clientes = await _context.Clientes.Where(c => c.Id == idCliente).ToListAsync();
            var marmitas = await _context.Marmitas.Where(m => m.Id == idMarmita && m.RetiradaEntrega == RetiradaEnum.Entrega).ToListAsync();
             
            var query = from marmita in marmitas
                        join cliente in clientes
                        on marmita.ClienteId equals cliente.Id
                        select new MarmitaRetiradaDto { Nome = cliente.Nome, Telefone = cliente.Telefone, Misturas = marmita.Misturas, Guarnicoes = marmita.Guarnicoes, Tamanho = marmita.Tamanho, Data = marmita.Data, };

            return query;            
        }


    }
}