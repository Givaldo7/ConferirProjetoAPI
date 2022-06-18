using ConferirAPI2.Models;
using FluentValidation;
using SolrNet.Utils;

namespace ConferirAPI2.Validator
{
    public class ConferirValidator : AbstractValidator<ClienteAPI>
    {
        public ConferirValidator()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(10).MaximumLength(150).WithMessage("o campo não pode estar vazio");
            RuleFor(m => m.Document).Must(d => d.IsValidDocument().NotNull()).WithMessage("Documento inválido");
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().MinimumLength(5).MaximumLength(150).WithMessage("Email inválido");
            RuleFor(x => x.Telefone).NotNull().NotEmpty().Matches("[2-9[0-9[10]").WithMessage("o telefone deve conter o formato [2-9][0-9]{10}");
            RuleFor(x => x.Endereco).NotNull().NotEmpty().MinimumLength(5).MaximumLength(150).WithMessage("o campo não pode estar vazio");
            RuleFor(x => x.Status).NotNull().NotEmpty();




        }




    }

        
    
}
