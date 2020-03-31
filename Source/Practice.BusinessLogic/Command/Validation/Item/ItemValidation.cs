using FluentValidation;
using Practice.BusinessLogic.Command.Base;
using Practice.BusinessLogic.Command.Interface;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.BusinessLogic.Validation
{
    public class ItemValidation : AbstractValidationHandler<ItemDTO>
    {
        public ItemValidation()
        {
            RuleFor(x => x.ItemName).NotEmpty().WithMessage("Item's name should not empty.");
            RuleFor(x => x.Unit).NotEmpty().Must(x => x>0).WithMessage("Unit's item should more than one.");
            RuleFor(x => x.Cost).NotEmpty().Must(x => x>0).WithMessage("Cost's item should more than one.");
            RuleFor(x => x.Barcode).NotEmpty().WithMessage("Barcode's item should not empty.");
            RuleFor(x => x.SKU).Must(x => x >= SKU.Beverage).WithMessage("SKU's item should not be empty.");
        }
        public string ValidationItemId(int itemId)
        {
            if (itemId <= 0)
            {
                return "Item's ID should not empty.";
            }

            return string.Empty;
        }
    }
}
