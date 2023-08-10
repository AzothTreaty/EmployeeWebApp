using FluentValidation;
using Sprout.Exam.Business.DataTransferObjects;

namespace FluentValidationDemo.Validation
{
    public class CalculateDtoValidator : AbstractValidator<CalculateDto>
    {
        public CalculateDtoValidator()
        {
            RuleFor(c => c.Id).NotNull().NotEmpty();
        }
    }
}