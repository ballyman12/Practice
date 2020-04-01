using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.BusinessLogic.Command.Interface;
using Practice.BusinessLogic.Command.Result;
using Practice.BusinessLogic.Command.Validation;
using Practice.BusinessLogic.Interface;
using Practice.BusinessLogic.Validation.Result;
using Practice.Domain.Model;
using Practice.WebAPI.Helpers;

namespace Practice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : BaseController
    {
        private ISupplierBusinessLogic supplierBusinessLogic { get; }
        private SupplierValidation supplierValidation { get; }
        public SuppliersController(ISupplierBusinessLogic supplierBusinessLogic, SupplierValidation supplierValidation)
        {
            this.supplierBusinessLogic = supplierBusinessLogic;
            this.supplierValidation = supplierValidation;
        }

        [HttpGet("Get-all-supplier")]
        public async Task<ActionResult<APIResponseWrapper<SupplierDTO[]>>> GetAllSupplier()
        {
            var suppliers = await supplierBusinessLogic.GetAllSuppliers();

            if (suppliers.Count <= 0) return NotFound();

            var suppiersDTO = suppliers.Select(x => x.ToDTO()).ToArray();

            return APIResponse(suppiersDTO);
        }

        [HttpGet("Get-supplier-by-Id/{supplierId}")]
        public async Task<ActionResult<APIResponseWrapper<SupplierDTO>>> GetSupplierById(int supplierId)
        {
            var supplier = await supplierBusinessLogic.GetSupplierById(supplierId);

            if (supplier == null) return NotFound();

            var suppierDTO = supplier.ToDTO();

            return APIResponse(suppierDTO);
        }

        [HttpPost("Create-supplier")]
        public async Task<ActionResult<APIResponseWrapper<SupplierDTO>>> CreateSupplier(SupplierDTO supplierDTO)
        {
            var validation = this.supplierValidation.Validate(supplierDTO, ruleSet: "creating");

            ValidationResult validationResut = new ValidationResult(validation);

            if (!validationResut.IsValid)
                return APIResponse<SupplierDTO>(validationResut);
            else
            {
                var result = await supplierBusinessLogic.CreateSupplier(supplierDTO);
                if (result is CommandResult command && !command.Success)
                    return APIResponse<SupplierDTO>(result, StatusCodes.Status400BadRequest);

                return APIResponse(new SupplierDTO()
                {
                    SupplierId = supplierDTO.SupplierId,
                    SupplierName = supplierDTO.SupplierName,
                    SupplierAddress = supplierDTO.SupplierAddress,
                    SupplierPhone = supplierDTO.SupplierPhone
                });
            }

        }

        [HttpPatch("Update-supplier")]
        public async Task<ActionResult<APIResponseWrapper<ICommandBase>>> UpdateSupplier(SupplierDTO supplierDTO)
        {

            var validation = this.supplierValidation.Validate(supplierDTO, ruleSet: "updating");

            ValidationResult validationResult = new ValidationResult(validation);

            if (validationResult.IsValid)
            {
                var result = await supplierBusinessLogic.UpdateSupplier(supplierDTO);
                return APIResponse(result, StatusCodes.Status400BadRequest);
            }

            return APIResponse<ICommandBase>(validationResult);
        }

        [HttpDelete("Delete-supplier")]
        public ActionResult<APIResponseWrapper<ICommandBase>> DeleteSupplier(int supplierId)
        {
            SupplierDTO supplierDTO = new SupplierDTO();
            supplierDTO.SupplierId = supplierId;

            var validation = this.supplierValidation.Validate(supplierDTO, ruleSet: "deleting");

            ValidationResult validationResult = new ValidationResult(validation);

            if (!validationResult.IsValid)
            {
                return APIResponse<ICommandBase>(validationResult);

            }

            var result = supplierBusinessLogic.DeleteSupplier(supplierId);

            return APIResponse(result, StatusCodes.Status400BadRequest);
        }
    }
}