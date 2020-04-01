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
    }
}
