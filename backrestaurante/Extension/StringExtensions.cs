using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace backrestaurante.Extension
{
    public static class StringExtensions
    {
        public static bool TelefoneValido(this string telefone)
        {
            var expression = "^[1-9]{2}(?:[2-8]|9[0-9])[0-9]{3}[0-9]{4}$";

            return Regex.Match(telefone, expression).Success;
        }
    }
}