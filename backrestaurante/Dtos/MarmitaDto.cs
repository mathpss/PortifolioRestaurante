using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Models;

namespace backrestaurante.Dtos
{
    public class MarmitaDto
    {


        public string Misturas { get; set; }

        public string Guarnicoes { get; set; }

        public RetiradaEnum RetiradaEntrega { get; set; }

        public TamanhoEnum Tamanho { get; set; }

        public DateTime Data { get; set; }
        public int ClienteId { get; set; }  
           
    }
}