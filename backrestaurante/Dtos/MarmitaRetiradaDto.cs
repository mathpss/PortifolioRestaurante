using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Models;

namespace backrestaurante.Dtos
{
    public class MarmitaRetiradaDto
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Misturas { get; set; }
        public string Guarnicoes { get; set; }
        public TamanhoEnum Tamanho { get; set; }
        public DateTime Data { get; set; } 
    }
}