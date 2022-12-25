using FluentValidation;
using iDev.Application.Commands.CreateUser;
using System.Text.RegularExpressions;

namespace iDev.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(P => P.Email)
                .EmailAddress()
                .WithMessage("E-mail não válido");

            RuleFor(P => P.Password)
                .Must(ValidPasseord)
                .WithMessage("senha deve conter pelo menos 8 caracteres e possui pelo menos uma letra e um número.");

            RuleFor(p => p.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome é Obrigatório");
        }

        public bool ValidPasseord(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
        
    }
}
