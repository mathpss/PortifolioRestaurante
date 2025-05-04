using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using backrestaurante.Models;

namespace backrestaurante.Entity
{
    public class Cliente
    {

        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string Nome { get; set; }
        [Required]
        [StringLength(70)]
        public string Telefone { get; set; }

        public Perfil Perfil { get; set; }
        public List<Endereco> Enderecos { get; set; }

        public List<Marmita> Marmitas { get; set; }
    }
}