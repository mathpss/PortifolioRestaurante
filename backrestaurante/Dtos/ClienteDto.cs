using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using backrestaurante.Entity;
using backrestaurante.Models;

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


        // public static explicit operator Cliente(ClienteDto request)
        // {
        //     return new Cliente()
        //     {
        //         Nome = request.Nome,
        //         Telefone = request.Telefone,
        //         Perfil = (request.Perfil == null) ? Perfil.Cliente : (Perfil)Enum.Parse(typeof(Perfil), request.Perfil)
        //     };
        // }
    }
}