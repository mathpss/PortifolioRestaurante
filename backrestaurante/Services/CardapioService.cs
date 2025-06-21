using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Context;
using backrestaurante.Entity;
using backrestaurante.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backrestaurante.Services
{
    public class CardapioService : ICardapioService
    {
        private readonly RestauranteContext _context;

        public CardapioService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task<Cardapio> GetCardapio(int id)
        {
            return await _context.Cardapios.FindAsync(id);
        }

        public async Task CriarCardapio(Cardapio cardapio)
        {
            await _context.Cardapios.AddAsync(cardapio);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cardapio>> ListaCardapio()
        {
            return await _context.Cardapios.ToListAsync();
        }

        public async Task RemoverCardapio(Cardapio cardapio)
        {
            _context.Cardapios.Remove(cardapio);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarCardapio(Cardapio cardapio)
        {
            _context.Cardapios.Update(cardapio);
            await _context.SaveChangesAsync();
        }
    }
}