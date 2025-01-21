using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backrestaurante.Dtos
{
    public class EnderecoDto
    {

        public string NomeRua { get; set; }

        public int NumeroRua { get; set; }

        public string Bairro { get; set; }
        public string Cidade { get; set; } 
        public int ClienteId { get; set; }       
    }
}