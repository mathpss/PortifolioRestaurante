using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backrestaurante.Dtos;
using FluentValidation;
using FluentValidation.Validators;
using backrestaurante.Extension;

namespace backrestaurante.Validators
{
    public class ClienteDtoValidator : AbstractValidator<ClienteDto>
    {
        public ClienteDtoValidator()
        {
            RuleFor(r => r.Nome)
                .NotEmpty()
                    .WithMessage("O nome não pode ser nulo ou vazio")
                .MaximumLength(70)
                    .WithMessage("O nome pode ter no máximo 70 caracteres");

            RuleFor(r => r.Telefone)
                .NotEmpty()
                    .WithMessage("O campo telefone é obrigatório")
                .MinimumLength(9)
                    .WithMessage("É preciso preencher com no mínimo 9 números")
                .Must(t => t.TelefoneValido())
                    .WithMessage("O formato passado do telefone é inválido");


                
        }
    }
}