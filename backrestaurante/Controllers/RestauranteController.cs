using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Dtos;
using backrestaurante.Entity;
using Microsoft.AspNetCore.Mvc;
using backrestaurante.Services.Interfaces;
using backrestaurante.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;

namespace backrestaurante.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class RestauranteController : ControllerBase
    {
        private const string Key = "Cardapio-Cache";
        private readonly IClienteService _clienteService;
        private readonly IMarmitaService _marmitaService;
        private readonly IEnderecoService _enderecoService;
        private readonly ICardapioService _cardapioService;

        private readonly IMemoryCache _memoryCache;
        public RestauranteController(IMarmitaService marmitaService,
                                        IClienteService clienteService,
                                        IEnderecoService enderecoService,
                                        ICardapioService cardapioService,
                                        IMemoryCache memoryCache)
        {
            _marmitaService = marmitaService;
            _clienteService = clienteService;
            _enderecoService = enderecoService;
            _cardapioService = cardapioService;
            _memoryCache = memoryCache;
        }

        #region Marmita 


        [HttpGet("RetiradaHoje")]
        [Tags("Marmita")]
        public async Task<ActionResult<Cliente>> RetiradaHoje()
        {
            var retiradaHoje = await _marmitaService.ListaRetiradaHoje();
            if (retiradaHoje == null) return NotFound("");
            return Ok(retiradaHoje);
        }
        [HttpGet("PedidosRetirados")]
        [Tags("Marmita")]
        public async Task<ActionResult<Cliente>> ListaRetirada()
        {
            var retirada = await _marmitaService.ListaRetirada();
            if (retirada == null) return NotFound();
            return Ok(retirada);
        }

        [HttpGet("EntregaHoje")]
        [Tags("Marmita")]
        public async Task<ActionResult<Cliente>> ListaEntregaHoje()
        {
            var pedidoEntrega = await _marmitaService.ListaEntregaHoje();
            if (pedidoEntrega == null) return NotFound("Sem pedidos");

            return Ok(pedidoEntrega);
        }
        [HttpGet("PedidosEntregues")]
        [Tags("Marmita")]
        public async Task<ActionResult<Cliente>> PedidoEntrega()
        {
            var pedidoEntrega = await _marmitaService.ListaEntrega();

            return Ok(pedidoEntrega);
        }



        [HttpGet("Marmita/{id:int}")]
        [Tags("Marmita")]
        public async Task<ActionResult<Marmita>> ObterMarmitaPorId(int id)
        {
            var marmita = await _marmitaService.ObterMarmitaPorId(id);
            if (marmita == null) throw new KeyNotFoundException("Pedido não encontrado no Banco de Dados");
            return Ok(marmita);
        }

        [HttpPost("Marmita")]
        [Tags("Marmita")]
        public async Task<ActionResult> CriarMarmita(MarmitaDto marmita)
        {
            var novaMarmita = (Marmita)marmita;
            await _marmitaService.CriarMarmita(novaMarmita);
            return CreatedAtAction(nameof(ObterMarmitaPorId), new { id = novaMarmita.Id }, novaMarmita);
        }

        #endregion

        #region Cliente        

        [HttpGet("Cliente/{id:int}")]
        [Tags("Cliente")]
        public async Task<ActionResult<Cliente>> ObterClientePorId(int id)
        {
            var cliente = await _clienteService.ObterClientePorId(id)
            ?? throw new KeyNotFoundException("Cliente não encontrado no Banco de Dados");
            return Ok(cliente);
        }

        [AllowAnonymous]
        [HttpPost("Cliente")]
        [Tags("Cliente")]

        public async Task<ActionResult> CriarCliente(ClienteDto cliente)
        {
            var novoCliente = new Cliente()
            {
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                Perfil = (cliente.Perfil == null) ? Perfil.Cliente : (Perfil)Enum.Parse(typeof(Perfil), cliente.Perfil)
            };

            var clienteExiste = await _clienteService.ClienteLogin(novoCliente);
            if (clienteExiste != null) throw new Exception("Já possui cadastro");


            await _clienteService.CriarCliente(novoCliente);
            return CreatedAtAction(nameof(ObterClientePorId), new { id = novoCliente.Id }, novoCliente);
        }

        [HttpPost("Cliente/Login")]
        [Tags("Cliente")]
        public async Task<ActionResult> ClienteLogin(ClienteDto cliente)
        {
            var clienteLogin = new Cliente()
            {
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                Perfil = (cliente.Perfil == null) ? Perfil.Cliente : (Perfil)Enum.Parse(typeof(Perfil), cliente.Perfil)

            };

            var clientelogado = await _clienteService.ClienteLogin(clienteLogin);
            var token = _clienteService.GerarTokenJwt(clientelogado);

            if (clientelogado != null) return Ok(new ClienteLogado
            {
                Nome = clientelogado.Nome,
                Telefone = clientelogado.Telefone,
                Perfil = clientelogado.Perfil.ToString(),
                Token = token
            });

            return Unauthorized();

        }

        #endregion

        #region Endereco

        [HttpGet("Endereco/{id:int}")]
        [Tags("Endereco")]
        public async Task<ActionResult<Endereco>> ObterEnderecoPorId(int id)
        {
            var endereco = await _enderecoService.ObterEnderecoPorId(id);
            if (endereco == null) throw new KeyNotFoundException("Endereço não encontrado no Banco de Dados");
            return Ok(endereco);
        }

        [HttpPost("Endereco")]
        [Tags("Endereco")]

        public async Task<ActionResult> CriarEndereco(EnderecoDto endereco)
        {
            var novoEndereco = (Endereco)endereco;

            await _enderecoService.CriarEndereco(novoEndereco);
            return CreatedAtAction(nameof(ObterEnderecoPorId), new { id = novoEndereco.Id }, novoEndereco);
        }

        #endregion

        #region Cardapio

        [HttpPost("Cardapio")]
        [Tags("Cardapio")]
        public async Task<ActionResult> CriarCardapio(Cardapio cardapio)
        {
            await _cardapioService.CriarCardapio(cardapio);

            return CreatedAtAction(nameof(GetCardapio), new { id = cardapio.Id }, cardapio);
        }

        [HttpGet("Cardapio/{id:int}")]
        [Tags("Cardapio")]

        public async Task<ActionResult<Cardapio>> GetCardapio(int id)
        {
            var cardapioDB = await _cardapioService.GetCardapio(id);
            if (cardapioDB == null) return NotFound();

            return Ok(cardapioDB);
        }

        [HttpGet("Cardapio")]
        [Tags("Cardapio")]
        public async Task<ActionResult<Cardapio>> ListaCardapio()
        {
            var cardapioDB = await _cardapioService.ListaCardapio();
            if (cardapioDB == null) return NotFound("Sem Lista de Cárdapio");

            if(_memoryCache.TryGetValue(Key, out List<Cardapio> listaCache))
            {
                return Ok(listaCache);
            }

            var memoryCacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(180),
                SlidingExpiration = TimeSpan.FromMinutes(10)
            };

            _memoryCache.Set(Key, cardapioDB, memoryCacheOptions);

            return Ok(cardapioDB);
        }

        [HttpPut("Cardapio/{id:int}")]
        [Tags("Cardapio")]

        public async Task<ActionResult> AtualizarCardapio(int id, Cardapio cardapio)
        {
            var cardapioDB = await _cardapioService.GetCardapio(id);
            if (cardapioDB == null) return NotFound();

            cardapioDB.Misturas = cardapio.Misturas;
            cardapioDB.Guarnicoes = cardapio.Guarnicoes;

            await _cardapioService.AtualizarCardapio(cardapioDB);

            var memoryCacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(180),
                SlidingExpiration = TimeSpan.FromMinutes(10)
            };

            _memoryCache.Set(Key, cardapioDB, memoryCacheOptions);
            
            return NoContent();
        }

        [HttpDelete("Cardapio{id:int}")]
        [Tags("Cardapio")]

        public async Task<ActionResult> DeleteCardapio(int id)
        {
            var cardapioDB = await _cardapioService.GetCardapio(id);
            if (cardapioDB == null) return NotFound();

            await _cardapioService.RemoverCardapio(cardapioDB);
            return NoContent();
        }

#endregion

    }
}