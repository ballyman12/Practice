using Practice.BusinessLogic.Command.Interface;
using Practice.Domain.Model;
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
    }
}
