using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Dtos;
using backrestaurante.Entity;

namespace backrestaurante.Services.Interfaces
{
    public interface IMarmitaService
    {
        public Task CriarMarmita(Marmita marmita);

        public Task<Marmita> ObterMarmitaPorId(int id);

        public Task<IEnumerable<MarmitaRetiradaDto>> MarmitaRetirada(int idMarmita, int idCliente);                 
        public Task<IEnumerable<MarmitaRetiradaDto>> MarmitaEntrega(int idMarmita, int idCliente);                 
    }
}