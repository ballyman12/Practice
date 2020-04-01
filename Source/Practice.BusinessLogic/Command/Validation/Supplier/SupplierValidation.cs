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
            RuleSet("creating", Creating);
            RuleSet("updating", Updating);
            RuleSet("deleting", Deleting);
        }

        public void Creating()
        {
            RuleFor(x => x.SupplierName).NotEmpty().WithMessage("Supplier's name should not empty.");
            RuleFor(x => x.SupplierAddress).NotEmpty().WithMessage("Supplier's address should more than one.");
            RuleFor(x => x.SupplierPhone).NotEmpty().WithMessage("Supplier's phone should more than one.");
        }
        public void Updating()
        {
            RuleFor(x => x.SupplierId).NotEmpty().WithMessage("Supplier's ID should not empty.");
            RuleFor(x => x.SupplierName).NotEmpty().WithMessage("Supplier's name should not empty.");
            RuleFor(x => x.SupplierAddress).NotEmpty().WithMessage("Supplier's address should more than one.");
            RuleFor(x => x.SupplierPhone).NotEmpty().WithMessage("Supplier's phone should more than one.");
        }
        public void Deleting()
        {
            RuleFor(x => x.SupplierId).NotEmpty().WithMessage("Supplier's ID should not empty.");
        }
    }
}
