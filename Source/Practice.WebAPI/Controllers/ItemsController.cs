using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.BusinessLogic.Interface;
using Practice.Domain.Model;
using Practice.WebAPI.Helpers;

namespace Practice.WebAPI.Controllers
{
    [Route("api/Items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private IItemBusinessLogic itemBusinessLogic { get; }
        public ItemsController(IItemBusinessLogic itemBusinessLogic)
        {
            this.itemBusinessLogic = itemBusinessLogic;
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
        public ActionResult<APIResponseWrapper<ItemDTO>> CreateItem(ItemDTO item)
        {
            if(item != null)
            {
                return APIResponseWrapper<ItemDTO>.StatusComplete(item);
            }

            return BadRequest("Error");
        }


    }
}