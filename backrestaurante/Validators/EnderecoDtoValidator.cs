using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Dtos;
using FluentValidation;
using backrestaurante.Extension;

namespace backrestaurante.Validators
{
    public class EnderecoDtoValidator : AbstractValidator<EnderecoDto>
    {
        public EnderecoDtoValidator()
        {
            RuleFor(r => r.NomeRua)
                .NotEmpty()
                    .WithMessage("O nome da rua não poder ser nulo ou vazio")
                .MaximumLength(70)
                    .WithMessage("Permitido no máximo 70 caracteres");

            RuleFor(r => r.NumeroRua)
                .NotEmpty()
                    .WithMessage("O número da rua não poder ser nulo ou vazio")
                .Must(n => n.NumeroRuaValido())
                    .WithMessage("Permitido apenas números");
                                    
        }
    }
}