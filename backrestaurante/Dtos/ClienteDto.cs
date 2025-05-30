using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backrestaurante.Dtos
{
    public class ClienteDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        [JsonIgnore]
        public string Perfil { get; set; }
    }
}