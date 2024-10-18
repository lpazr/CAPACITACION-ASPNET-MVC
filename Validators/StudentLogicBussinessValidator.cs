using ExampleWeb.Models.Entitys;
using FluentValidation;

namespace ExampleWeb.Validators
{
    public class StudentLogicBussinessValidator : AbstractValidator<Student>
    {
        private const int MAX_LENGTH_NAME = 10;
        private const int MAX_LENGTH_EMAIL = 10;
        private const int LENGTH_PHONE = 9;
        public StudentLogicBussinessValidator()
        {
            RuleFor(s=>s.Name)
                .Length(1, MAX_LENGTH_NAME)
                .WithMessage($"La longitud del Nombre no puede exceder los {MAX_LENGTH_NAME} caracteres");
            RuleFor(s=>s.Email)
                .Length (1, MAX_LENGTH_EMAIL)
                .WithMessage($"La longitud del Correo no puede exceder los {MAX_LENGTH_EMAIL} caracteres");

            RuleFor(s => s.Email)
                .EmailAddress()
                .WithMessage("La dirección de Correo no es válida");
            RuleFor(s => s.Phone)
                .Length(LENGTH_PHONE)
                .WithMessage($"La longitud del Telefono debe ser de  {LENGTH_PHONE} números.");
        }
    }
}
