using Practice.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Domain.Model
{
    public class Order : EntityDescription
    {
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public OrderDTO ToOrderDTO(Order order)
        {
            var orderItems = new List<OrderItemDTO>();
 
            orderItems.AddRange(order.OrderItems.Select(c => c.ToOrderItemDTO(c)));
            return new OrderDTO()
            {
                OrderId = order.Id,
                OrderName = order.Name,   
                SupplierName = order.Supplier?.Name,
                OrderItemsDTO = orderItems
            };
        }

    }
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public string SupplierName { get; set; }
        public List<OrderItemDTO> OrderItemsDTO { get; set; }

    }
    public class OrderCreateCommand
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public int SupplierId { get; set; }
        public IEnumerable<int> ItemsId { get; set; }
    }
}
