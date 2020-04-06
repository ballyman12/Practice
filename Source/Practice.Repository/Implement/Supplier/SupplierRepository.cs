using Microsoft.EntityFrameworkCore;
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

namespace Practice.Repository.Implement
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly PracticeContext practiceContext;
        public SupplierRepository(PracticeContext practiceContext)
        {
            this.practiceContext = practiceContext;
        }  
        public async Task<IList<Supplier>> GetAllSupplier()
        {
            return await practiceContext.Suppliers.ToListAsync();
        }
        public async Task<Supplier> GetSupplierById(int supplierId)
        {
            return await practiceContext.Suppliers.FirstOrDefaultAsync(x => x.Id == supplierId);
        }

        public async Task<ICommandBase> CreateSupplier(Supplier supplier)
        {
            var hasSupplierName = practiceContext.Suppliers.Any(x => x.Name.ToLower().Equals(supplier.Name.ToLower()));
            if (hasSupplierName)
                return new CommandResult(false, $"Supplier's name '{supplier.Name}' has already exists");

           

            practiceContext.Suppliers.Add(supplier);
            await practiceContext.SaveChangesAsync();

            

            return new CommandResult();

        }
        public async Task<ICommandBase> UpdateSupplier(Supplier supplier)
        {
            var _supplier = practiceContext.Suppliers.FirstOrDefault(x => x.Id == supplier.Id);
            if (_supplier == null)
                return new CommandResult(false, $"Supplier not found.");

            var hasSupplierName = practiceContext.Suppliers.Any(x => x.Name.ToLower().Equals(supplier.Name.ToLower()) && x.Id != supplier.Id);
            if (hasSupplierName)
                return new CommandResult(false, $"Supplier's name '{supplier.Name}' has already exists");

            _supplier.Name = supplier.Name;
            _supplier.Address = supplier.Address;
            _supplier.PhoneNo = supplier.PhoneNo;

            practiceContext.Suppliers.Update(_supplier);
            await practiceContext.SaveChangesAsync();

            return new CommandResult();
        }

        public async Task<ICommandBase> DeleteSupplier(int supplierId)
        {
            var _supplier = practiceContext.Suppliers.FirstOrDefault(x => x.Id == supplierId);

            if (_supplier == null)
                return new CommandResult(false, $"Supplier not found.");

            practiceContext.Suppliers.Remove(_supplier);
            await practiceContext.SaveChangesAsync();

            return new CommandResult();

        }
    }
}
