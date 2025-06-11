using MediatR;
using MultiShop.Order.Applications.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Applications.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Applications.Features.Mediator.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
    {
        private readonly IGenericRepository<Ordering> _genericRepository;

        public CreateOrderingCommandHandler(IGenericRepository<Ordering> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.CreateAsync(new Ordering
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId
            });
        }
    }
}
