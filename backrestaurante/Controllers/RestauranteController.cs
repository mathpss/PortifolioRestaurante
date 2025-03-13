using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Dtos;
using backrestaurante.Entity;
using Microsoft.AspNetCore.Mvc;
using backrestaurante.Services.Interfaces;
using backrestaurante.Models;

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

        [HttpGet("Marmita/{id:int}")]
        public async Task<ActionResult<Marmita>> ObterMarmitaPorId(int id)
        {
            var marmita = await _marmitaService.ObterMarmitaPorId(id);
            if (marmita == null) throw new KeyNotFoundException("Pedido não encontrado no Banco de Dados");
            return Ok(marmita);
        }

        [HttpPost("Marmita")]
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
        
        [HttpGet("Cliente/{id:int}")]

        public async Task<ActionResult<Cliente>> ObterClientePorId(int id)
        {
            var cliente = await _clienteService.ObterClientePorId(id);
            if (cliente == null) throw new KeyNotFoundException("Cliente não encontrado no Banco de Dados");
            return Ok(cliente);           
        }


        [HttpPost("Cliente")]

        public async Task<ActionResult>CriarCliente(ClienteDto cliente)
        {
            var novoCliente = new Cliente()
            {
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                Perfil = (cliente.Perfil == null) ? Perfil.Cliente : (Perfil) Enum.Parse(typeof(Perfil), cliente.Perfil)
            };

            var clienteExiste = await _clienteService.ClienteLogin(novoCliente);
            if (clienteExiste != null) throw new Exception("Já possui cadastro");


            await _clienteService.CriarCliente(novoCliente);
            return CreatedAtAction(nameof(ObterClientePorId), new { id = novoCliente.Id }, novoCliente);
        }

        [HttpPost("Cliente/Login")]
        public async Task<ActionResult>ClienteLogin(ClienteDto cliente)
        {
            var clienteLogin = new Cliente()
            {
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                Perfil = (cliente.Perfil == null) ? Perfil.Cliente : (Perfil) Enum.Parse(typeof(Perfil), cliente.Perfil)
                  
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



        [HttpGet("Endereco/{id:int}")]
        public async Task<ActionResult<Endereco>>ObterEnderecoPorId(int id)
        {
            var endereco = await _enderecoService.ObterEnderecoPorId(id);
            if (endereco == null) throw new KeyNotFoundException("Endereço não encontrado no Banco de Dados");
            return Ok(endereco);              
        }

        [HttpPost("Endereco")]

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