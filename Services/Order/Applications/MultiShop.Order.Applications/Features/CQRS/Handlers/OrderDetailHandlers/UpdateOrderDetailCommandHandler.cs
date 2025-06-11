using MultiShop.Order.Applications.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Applications.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Applications.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Applications.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IGenericRepository<OrderDetail> _genericRepository;

        public UpdateOrderDetailCommandHandler(IGenericRepository<OrderDetail> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _genericRepository.GetByIdAsync(command.OrderDetailId);
            values.OrderingId = command.OrderingId;
            values.ProductId    = command.ProductId;    
            values.ProductName = command.ProductName;
            values.ProductPrice = command.ProductPrice;
            values.ProductAmount = command.ProductAmount;
            values.ProductTotalPrice = command.ProductTotalPrice;   
            await _genericRepository.UpdateAsync(values);



        }
    }
}
