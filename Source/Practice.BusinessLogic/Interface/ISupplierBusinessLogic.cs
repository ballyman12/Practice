
using Practice.Domain.Model;
using Practice.Domain.Result.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BusinessLogic.Interface
{
    public interface ISupplierBusinessLogic : IBusinessLogicBase<Supplier>
    {
        Task<IList<Supplier>> GetAllSuppliers();
        Task<Supplier> GetSupplierById(int supplierId);
        Task<ICommandBase> CreateSupplier(SupplierDTO supplier);
        Task<ICommandBase> UpdateSupplier(SupplierDTO supplier);
        Task<ICommandBase> DeleteSupplierAsync(int supplierId);
    }
}
