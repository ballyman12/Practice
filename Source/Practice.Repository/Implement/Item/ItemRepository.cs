using Practice.DataAccess.Implementation;
using Practice.Domain.Model;
using Practice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Practice.Repository.Implement
{
    public class ItemRepository : IItemRepository
    {
        private readonly PracticeContext practiceContext;
        public ItemRepository(PracticeContext practiceContext)
        {
            this.practiceContext = practiceContext;
        }
        public void Delete(int internalId)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetById(int internalId)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Item>> GetList()
        {
            return await practiceContext.Items.ToListAsync();
        }

        public Task<Item> Save(Domain.Model.Item item)
        {
            throw new NotImplementedException();
        }

        public Task<Item> Update(Domain.Model.Item item)
        {
            throw new NotImplementedException();
        }
    }
}
