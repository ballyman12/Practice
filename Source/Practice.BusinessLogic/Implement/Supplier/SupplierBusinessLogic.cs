using Practice.BusinessLogic.Interface;
using Practice.Domain.Model;
using Practice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BusinessLogic.Implement
{
    public class SupplierBusinessLogic : ISupplierBusinessLogic
    {
        private readonly ISupplierRepository suplierRepository;
        public SupplierBusinessLogic(ISupplierRepository suplierRepository)
        {
            this.suplierRepository = suplierRepository;
        }
        public async Task<IList<Supplier>> GetAllSuppliers()
        {
            return await suplierRepository.GetAllSupplier();
        }

        public async Task<Supplier> GetSupplierById(int supplierId)
        {
            return await suplierRepository.GetSupplierById(supplierId);
        }
    }
}
