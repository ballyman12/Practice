using FluentValidation;
using Practice.BusinessLogic.Command.Base;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.BusinessLogic.Command.Validation
{
    public class SupplierValidation : AbstractValidationHandler<SupplierDTO>
    {
        public SupplierValidation()
        {
            RuleFor(x => x.SupplierName).NotEmpty().WithMessage("Supplier's name should not empty.");
            RuleFor(x => x.SupplierAddress).NotEmpty().WithMessage("Supplier's address should more than one.");
            RuleFor(x => x.SupplierPhone).NotEmpty().WithMessage("Supplier's phone should more than one.");
        }
    }
}
