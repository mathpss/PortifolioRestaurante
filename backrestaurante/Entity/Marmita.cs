using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using backrestaurante.Models;

namespace backrestaurante.Entity
{
    public class Marmita
    {
        public int Id { get; set; }

        public string Misturas { get; set; }

        public string Guarnicoes { get; set; }

        public RetiradaEnum RetiradaEntrega { get; set; }

        public TamanhoEnum Tamanho { get; set; }

        public DateTime Data { get; set; } 

        public int ClienteId { get; set; }
        
        [JsonIgnore]
        public Cliente Cliente { get; set; }

    }
}