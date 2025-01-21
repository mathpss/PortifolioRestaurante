using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Dtos;
using backrestaurante.Entity;
using backrestaurante.Services;
using Microsoft.AspNetCore.Mvc;

namespace backrestaurante.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestauranteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMarmitaService _marmitaService;
        private readonly IEnderecoService _enderecoService;
        public RestauranteController(IMarmitaService marmitaService,
                                        IClienteService clienteService,
                                        IEnderecoService enderecoService )
        {
            _marmitaService = marmitaService;
            _clienteService = clienteService;
            _enderecoService = enderecoService;
        }

        [HttpGet("ObterMarmitaPorId/{id:int}")]
        public async Task<ActionResult<Marmita>> ObterMarmitaPorId(int id)
        {
            var marmita = await _marmitaService.ObterMarmitaPorId(id);
            if (marmita == null) return NotFound();
            return Ok(marmita);
        }

        [HttpPost("CriarMarmita")]
        public async Task<ActionResult> CriarMarmita( MarmitaDto marmita)
        {
            var novaMarmita = new Marmita()
            {
                Misturas = marmita.Misturas,
                Guarnicoes = marmita.Guarnicoes,
                RetiradaEntrega = marmita.RetiradaEntrega,
                Tamanho = marmita.Tamanho,
                Data = marmita.Data,
                ClienteId = marmita.ClienteId
            };
            await _marmitaService.CriarMarmita(novaMarmita);
            return CreatedAtAction(nameof(ObterMarmitaPorId), new { id = novaMarmita.Id }, novaMarmita);
        }
        
        [HttpGet("ObterClientePorId/{id:int}")]

        public async Task<ActionResult<Cliente>> ObterClientePorId(int id)
        {
            var cliente = await _clienteService.ObterClientePorId(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);           
        }


        [HttpPost("CriarCliente")]

        public async Task<ActionResult>CriarCliente(ClienteDto cliente)
        {
            var novoCliente = new Cliente(){
                Nome = cliente.Nome,
                Telefone = cliente.Telefone
            };
            await _clienteService.CriarCliente(novoCliente);
            return CreatedAtAction(nameof(ObterClientePorId), new { id = novoCliente.Id }, novoCliente);
        }

        [HttpGet("ObterEnderecoPorId/{id:int}")]
        public async Task<ActionResult<Endereco>>ObterEnderecoPorId(int id)
        {
            var endereco = await _enderecoService.ObterEnderecoPorId(id);
            if (endereco == null) return NotFound();
            return Ok(endereco);              
        }

        [HttpPost("CriarEndereco")]

        public async Task<ActionResult>CriarEndereco(EnderecoDto endereco)
        {
            var novoEndereco = new Endereco()
            {
                NomeRua = endereco.NomeRua,
                NumeroRua = endereco.NumeroRua,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                ClienteId = endereco.ClienteId
            };

            await _enderecoService.CriarEndereco(novoEndereco);
            return CreatedAtAction(nameof(ObterEnderecoPorId), new { id = novoEndereco.Id }, novoEndereco);
        }
        
    }
}