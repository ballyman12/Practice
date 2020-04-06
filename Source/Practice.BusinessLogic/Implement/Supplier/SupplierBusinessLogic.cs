
using Practice.BusinessLogic.Interface;
using Practice.DataAccess.Implementation;
using Practice.Domain.Model;
using Practice.Domain.Result;
using Practice.Domain.Result.Interface;
using Practice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ICommandBase> CreateSupplier(SupplierDTO supplier)
        {
            var _supplier = new Supplier()
            {
                Name = supplier.SupplierName,
                Address = supplier.SupplierAddress,
                PhoneNo = supplier.SupplierPhone
            };

            var result = await suplierRepository.CreateSupplier(_supplier);
            supplier.SupplierId = _supplier.Id;

            return result;

        }

        public async Task<ICommandBase> UpdateSupplier(SupplierDTO supplier)
        {
            var _supplier = new Supplier()
            {
                Id = supplier.SupplierId,
                Name = supplier.SupplierName,
                Address = supplier.SupplierAddress,
                PhoneNo = supplier.SupplierPhone
            };

            return await suplierRepository.UpdateSupplier(_supplier);

        }

        public async Task<ICommandBase> DeleteSupplierAsync(int supplierId)
        {
            return await suplierRepository.DeleteSupplier(supplierId);

        }
    }
}
