using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Entity;

namespace backrestaurante.Services
{
    public interface IMarmitaService
    {
        public Task CriarMarmita(Marmita marmita);

        public Task<Marmita> ObterMarmitaPorId(int id);
    }
}