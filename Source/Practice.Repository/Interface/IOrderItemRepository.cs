using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Repository.Interface
{
    public interface IOrderItemRepository
    {
        Task UpdateOrdertem(IEnumerable<int> itemId, int orderId);
    }
}
