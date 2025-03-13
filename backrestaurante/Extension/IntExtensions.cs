using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace backrestaurante.Extension
{
    public static class IntExtensions
    {
        public static bool NumeroRuaValido(this int numerorua)
        {
            var expression = @"^\d+$";

            return Regex.Match(numerorua.ToString(), expression).Success;
        }
    }
}