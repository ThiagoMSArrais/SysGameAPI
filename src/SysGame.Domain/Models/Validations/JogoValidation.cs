using FluentValidation;

namespace SysGame.Domain.Models.Validations
{
    public class JogoValidation : AbstractValidator<Jogo>
    {
        public JogoValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo nome precisa ser fornecido")
                .Length(2, 150).WithMessage("O campo nome precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
