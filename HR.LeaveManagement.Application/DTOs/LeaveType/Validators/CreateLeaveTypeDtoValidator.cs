using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValidator:AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator() {
            RuleFor(p => p.Name)
                    .NotEmpty().WithMessage("{PropertyName} is required")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceeds 50 characters");
            RuleFor(p => p.DefaultDays)
                .NotEmpty().WithMessage("{PripertyName} is required")
                .GreaterThan(0).WithMessage("{PripertyName} must be at least 1")
                .LessThan(100).WithMessage("{PripertyName} must not exceed 100");


        }
    }
}
