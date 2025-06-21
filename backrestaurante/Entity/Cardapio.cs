using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Models;

namespace backrestaurante.Entity
{
    public class Cardapio
    {
        public int Id { get; set; }
        public List<string> Misturas { get; set; }
        public List<string> Guarnicoes { get; set; }
    }
}