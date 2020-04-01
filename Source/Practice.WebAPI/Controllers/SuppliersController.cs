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
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : BaseController
    {
        private ISupplierBusinessLogic supplierBusinessLogic { get; }
        public SuppliersController(ISupplierBusinessLogic supplierBusinessLogic)
        {
            this.supplierBusinessLogic = supplierBusinessLogic;
        }

        [HttpGet("Get-all-supplier")]
        public async Task<ActionResult<APIResponseWrapper<SupplierDTO[]>>> GetAllSupplier()
        {
            var suppliers = await supplierBusinessLogic.GetAllSuppliers();

            if (suppliers.Count <= 0) return NotFound();

            var suppiersDTO = suppliers.Select(x => x.ToDTO()).ToArray();

            return APIResponse(suppiersDTO);
        }
    }
}