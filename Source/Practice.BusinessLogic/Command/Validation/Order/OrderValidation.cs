using FluentValidation;
using Practice.BusinessLogic.Command.Base;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.BusinessLogic.Command.Validation
{
    public class OrderValidation : AbstractValidationHandler<OrderCreateCommand>
    {
        public OrderValidation()
        {
            RuleSet("creating", Creating);
            RuleSet("updating", Updating);
            RuleSet("deleting", Deleting);
        }
        public void Creating()
        {
            RuleFor(x => x.OrderName).NotEmpty().WithMessage("Order's name should not empty.");
            RuleFor(x => x.SupplierId).NotEmpty().WithMessage("Supplier's id should not empty.");
            RuleFor(x => x.ItemsId).NotEmpty().WithMessage("Supplier's phone should more than one.");
        }
        public void Updating()
        {
            RuleFor(x => x.OrderId).NotEmpty().WithMessage("Order's ID should not empty.");
            RuleFor(x => x.OrderName).NotEmpty().WithMessage("Order's name should not empty.");
            RuleFor(x => x.SupplierId).NotEmpty().WithMessage("Supplier's id should not empty.");
            RuleFor(x => x.ItemsId).NotEmpty().WithMessage("Item's ID should more than one.");
        }
        public void Deleting()
        {
            RuleFor(x => x.OrderId).NotEmpty().WithMessage("Supplier's ID should not empty.");
        }
    }
}
