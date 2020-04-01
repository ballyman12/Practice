using Practice.BusinessLogic.Command.Interface;
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
    public class OrderBusinessLogic : IOrderBusinessLogic
    {
        private readonly IOrderRepository orderRepository;
        private readonly IItemRepository itemRepository;
        private readonly ISupplierRepository supplierRepository;
        private readonly PracticeContext practiceContext;
        public OrderBusinessLogic(IItemRepository itemRepository, ISupplierRepository supplierRepository, IOrderRepository orderRepository, PracticeContext practiceContext)
        {
            this.itemRepository = itemRepository;
            this.supplierRepository = supplierRepository;
            this.orderRepository = orderRepository;
            this.practiceContext = practiceContext;
        }
        public Task<ICommandBase> CreateOrder(OrderDTO item)
        {
            throw new NotImplementedException();
        }

        public ICommandBase DeleteOrder(int itemId)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Order>> GetAllOrders()
        {
            var orders = await orderRepository.GetAllOrder();

            foreach (var order in orders)
            {
                var supplier = await supplierRepository.GetSupplierById(order.SupplierId);
                order.Supplier = supplier;

                foreach (var orderItem in order.OrderItems)
                {
                    var item = await itemRepository.GetItemById(orderItem.ItemId);
                    orderItem.Item = item;
                }
            }

            //var list = orders.Select(x => x.OrderItems.Select(c => c.ItemId));
            //var item_ist = list.Select(x => ));

            return orders;

        }

        public Task<Order> GetOrderById(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<ICommandBase> UpdateOrder(OrderDTO oder)
        {
            throw new NotImplementedException();
        }
    }
}
