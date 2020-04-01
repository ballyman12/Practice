using Practice.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Domain.Model
{
    public class OrderItem : EntityDescription
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public OrderItemDTO ToOrderItemDTO(OrderItem orderItem)
        {
            return new OrderItemDTO()
            {
                ItemId = orderItem.ItemId,
                ItemName = orderItem.Item?.Name,
                ItemCost = orderItem.Item.Cost
            };
        }

    }
    public class OrderItemDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double ItemCost { get; set; }

    }
}
