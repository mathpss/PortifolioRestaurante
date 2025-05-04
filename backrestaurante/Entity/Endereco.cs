using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backrestaurante.Entity
{
    public class Endereco
    {
        public int Id { get; set; }
        [StringLength(70)]
        public string NomeRua { get; set; }
        [StringLength(10)]
        public int NumeroRua { get; set; }
        [StringLength(70)]
        public string Bairro { get; set; }
        [StringLength(70)]
        public string Cidade { get; set; }

        public int ClienteId { get; set; }

        
    }
}