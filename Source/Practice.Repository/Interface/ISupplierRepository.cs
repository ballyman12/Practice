using Practice.Domain.Model;
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
        Task<Supplier> CreateSupplier(Supplier supplier);
        Task<Supplier> UpdateSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
    }
}
