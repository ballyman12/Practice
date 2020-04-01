using Practice.BusinessLogic.Command.Interface;
using Practice.BusinessLogic.Command.Result;
using Practice.BusinessLogic.Interface;
using Practice.DataAccess.Implementation;
using Practice.Domain.Model;
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
        private readonly PracticeContext practiceContext;
        public SupplierBusinessLogic(ISupplierRepository suplierRepository, PracticeContext practiceContext)
        {
            this.suplierRepository = suplierRepository;
            this.practiceContext = practiceContext;
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
            var hasSupplierName = practiceContext.Suppliers.Any(x => x.Name.ToLower().Equals(supplier.SupplierName.ToLower()));
            if(hasSupplierName)
                return new CommandResult(false, $"Supplier's name '{supplier.SupplierName}' has already exists");
            var _supplier = new Supplier()
            {
                Name = supplier.SupplierName,
                Address = supplier.SupplierAddress,
                PhoneNo = supplier.SupplierPhone
            };

            await suplierRepository.CreateSupplier(_supplier);
            supplier.SupplierId = _supplier.Id;

            return new CommandResult();

        }
    }
}
