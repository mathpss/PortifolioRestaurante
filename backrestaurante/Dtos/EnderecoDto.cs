using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Entity;

namespace backrestaurante.Dtos
{
    public class EnderecoDto
    {

        public string NomeRua { get; set; }

        public int NumeroRua { get; set; }

        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int ClienteId { get; set; }

        public static explicit operator Endereco(EnderecoDto request)
        {
             return  new Endereco()
            {
                NomeRua = request.NomeRua,
                NumeroRua = request.NumeroRua,
                Bairro = request.Bairro,
                Cidade = request.Cidade,
                ClienteId = request.ClienteId
            };
        }   
    }
}