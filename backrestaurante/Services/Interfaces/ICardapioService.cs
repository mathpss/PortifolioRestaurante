using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Entity;

namespace backrestaurante.Services.Interfaces
{
    public interface ICardapioService
    {
        public Task CriarCardapio(Cardapio cardapio);
        public Task AtualizarCardapio(Cardapio cardapio);
        public Task RemoverCardapio(Cardapio cardapio);
        public Task<Cardapio> GetCardapio(int id);
        public Task<IEnumerable<Cardapio>> ListaCardapio();
    }
}