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
        private readonly IItemBusinessLogic itemBusinessLogic;
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

    }
}