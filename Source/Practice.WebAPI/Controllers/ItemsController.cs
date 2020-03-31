using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.BusinessLogic.Command.Interface;
using Practice.BusinessLogic.Command.Result;
using Practice.BusinessLogic.Interface;
using Practice.BusinessLogic.Validation;
using Practice.BusinessLogic.Validation.Result;
using Practice.Domain.Model;
using Practice.WebAPI.Helpers;

namespace Practice.WebAPI.Controllers
{
    [Route("api/Items")]
    [ApiController]
    public class ItemsController : BaseController
    {
        private IItemBusinessLogic itemBusinessLogic { get; }
        private ItemValidation itemValidation { get; }

        public ItemsController(IItemBusinessLogic itemBusinessLogic, ItemValidation itemValidation)
        {
            this.itemBusinessLogic = itemBusinessLogic;
            this.itemValidation = itemValidation;
        }

        [HttpGet("GetAllItem")]
        public async Task<ActionResult<APIResponseWrapper<ItemDTO[]>>> GetAllItems()
        {
            var items = await itemBusinessLogic.GetAllItems();

            if (items == null) return NotFound();

            var itemDTO = items.Select(c => c.ToDTO()).ToArray();
            var itemResult = APIResponseWrapper<ItemDTO[]>.StatusComplete(itemDTO);

            return itemResult;

        }

        [HttpGet("GetItemById/{itemId}")]
        public async Task<ActionResult<APIResponseWrapper<ItemDTO>>> GetItemById(int itemId)
        {
            var item = await itemBusinessLogic.GetItemById(itemId);

            if (item == null) return NotFound();

            var itemDTO = item.ToDTO();

            return APIResponseWrapper<ItemDTO>.StatusComplete(itemDTO);
        }

        [HttpPost("Create-new-item")]
        public async Task<ActionResult<APIResponseWrapper<ItemDTO>>> CreateItem(ItemDTO item)
        {
            IValidationBase<ItemDTO> itemValidation = new ItemValidation();
            ValidationResult validationResult = itemValidation.Validate(item);


            if (!validationResult.IsValid)
                return APIResponse<ItemDTO>(validationResult);
            if (validationResult.IsValid)
            {
                var result = await itemBusinessLogic.CreateItem(item);
                return APIResponse<ItemDTO>(result, StatusCodes.Status400BadRequest);

            }


            return APIResponse(
                new ItemDTO()
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    Cost = item.Cost,
                    Unit = item.Unit,
                    SKU = item.SKU,
                    Barcode = item.Barcode
                });
        }

        [HttpPatch("Update-item")]
        public async Task<ActionResult<APIResponseWrapper<ICommandBase>>> UpdateItem(ItemDTO item)
        {
            ValidationResult validationResult = this.itemValidation.Validate(item);

            if (validationResult.IsValid)
            {
                var result = await itemBusinessLogic.UpdateItem(item);
                return APIResponse(result, StatusCodes.Status400BadRequest);

            }


            return APIResponse<ICommandBase>(validationResult, StatusCodes.Status400BadRequest);
        }

        [HttpDelete("Delete-item")]
        public ActionResult<APIResponseWrapper<ICommandBase>> DeleteItem(int itemId)
        {
            var validationItemId = this.itemValidation.ValidationItemId(itemId);
            if (!string.IsNullOrEmpty(validationItemId))
            {
                ValidationResult validationResult = new ValidationResult();
                validationResult.Errors.Add(new ValidationError()
                {
                    AttemptedValue = itemId,
                    ErrorMessage = validationItemId,
                    PropertyName = "ItemId"
                });

                return APIResponse<ICommandBase>(validationResult, StatusCodes.Status400BadRequest);
            }

            var result = itemBusinessLogic.DeleteItem(itemId);

            return APIResponse<ICommandBase>(result, StatusCodes.Status400BadRequest);



        }


    }
}