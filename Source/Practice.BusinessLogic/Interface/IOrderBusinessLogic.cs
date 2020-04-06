﻿using Practice.BusinessLogic.Command.Interface;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BusinessLogic.Interface
{
    public interface IOrderBusinessLogic : IBusinessLogicBase<Order>
    {
        Task<IList<Order>> GetAllOrders();
        Task<Order> GetOrderById(int orderId);
        Task<ICommandBase> CreateOrder(OrderCreateCommand order);
        Task<ICommandBase> UpdateOrder(OrderCreateCommand order);
        ICommandBase DeleteOrder(int orderId);
    }
}
