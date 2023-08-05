

using FluentValidation;
using Sprout.Exam.Business.DataTransferObjects;

namespace FluentValidationDemo.Validation
{
    public class EditEmployeeDtoValidator : AbstractValidator<EditEmployeeDto>
    {
        public EditEmployeeDtoValidator()
        {
            RuleFor(c => c.Id).NotNull().NotEmpty();
            RuleFor(c => c.SalaryAmount).NotNull().NotEmpty();
            RuleFor(c => c.Birthdate).NotNull().NotEmpty();
            RuleFor(c => c.FullName).NotNull().NotEmpty();
            RuleFor(c => c.TypeId).NotNull().NotEmpty();
            RuleFor(c => c.Tin).NotNull().NotEmpty();
        }
    }
}