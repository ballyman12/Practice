using Practice.Domain.Model;
using Practice.Domain.Result.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Repository.Interface
{
    public interface ISupplierRepository : IRepositoryBase<Supplier>
    {
        Task<IList<Supplier>> GetAllSupplier();
        Task<Supplier> GetSupplierById(int supplierId);
        Task<ICommandBase> CreateSupplier(Supplier supplier);
        Task<ICommandBase> UpdateSupplier(Supplier supplier);
        Task<ICommandBase> DeleteSupplier(int supplierId);
    }
}
