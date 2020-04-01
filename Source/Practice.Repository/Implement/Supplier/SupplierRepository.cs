using Microsoft.EntityFrameworkCore;
using Practice.DataAccess.Implementation;
using Practice.Domain.Model;
using Practice.Repository.Interface;
using System;
using System.Collections.Generic;
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
    }
}
