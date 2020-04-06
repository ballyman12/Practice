
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
    public class OrderBusinessLogic : IOrderBusinessLogic
    {
        private readonly IOrderRepository orderRepository;
        private readonly IItemRepository itemRepository;
        private readonly ISupplierRepository supplierRepository;
        private readonly IOrderItemRepository orderItemRepository;
        private readonly PracticeContext practiceContext;
        public OrderBusinessLogic(IItemRepository itemRepository, ISupplierRepository supplierRepository, IOrderRepository orderRepository, PracticeContext practiceContext , IOrderItemRepository orderItemRepository)
        {
            this.itemRepository = itemRepository;
            this.supplierRepository = supplierRepository;
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
            this.practiceContext = practiceContext;
        }
        public async Task<ICommandBase> CreateOrder(OrderCreateCommand order)
        {
            var hasOrderName = practiceContext.Order.Any(c => c.Name.ToLower().Equals(order.OrderName.ToLower()));
            if (hasOrderName)
                return new CommandResult(false, $"Order's name {order.OrderName} has already exists");

            var _order = new Order
            {
                Name = order.OrderName,
                SupplierId = order.SupplierId

            };

            await orderRepository.CreateOrder(_order);

            await orderItemRepository.UpdateOrdertem(order.ItemsId, _order.Id);

            order.OrderId = _order.Id;
            return new CommandResult();
        }

        public ICommandBase DeleteOrder(int itemId)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Order>> GetAllOrders()
        {
            var orders = await orderRepository.GetAllOrder();

            if (orders == null) return null;

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

            return orders;

        }

        public async Task<Order> GetOrderById(int orderId)
        {
            var order = await orderRepository.GetOrderById(orderId);

            if (order == null) return null;

            var supplier = await supplierRepository.GetSupplierById(order.SupplierId);
            order.Supplier = supplier;

            foreach (var orderItem in order.OrderItems)
            {
                var item = await itemRepository.GetItemById(orderItem.ItemId);
                orderItem.Item = item;
            }

            return order;
        }

        public async Task<ICommandBase> UpdateOrder(OrderCreateCommand order)
        {
            var _order = practiceContext.Order.FirstOrDefault(x => x.Id == order.OrderId);
            if(_order == null) return new CommandResult(false, $"Order not found.");


            var hasOrderName = practiceContext.Order.Any(c => c.Name.ToLower().Equals(order.OrderName.ToLower()) && c.Id != order.OrderId);
            if (hasOrderName)
                return new CommandResult(false, $"Order's name {order.OrderName} has already exists");

            _order.Name = order.OrderName;
            _order.SupplierId = order.SupplierId;

            await orderRepository.UpdateOrder(_order);

            await orderItemRepository.UpdateOrdertem(order.ItemsId, _order.Id);

            return new CommandResult();
        }
    }
}
