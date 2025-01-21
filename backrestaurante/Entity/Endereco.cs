using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backrestaurante.Entity
{
    public class Endereco
    {
        public int Id { get; set; }
        public string NomeRua { get; set; }

        public int NumeroRua { get; set; }

        public string Bairro { get; set; }
        public string Cidade { get; set; }

        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; }        
    }
}