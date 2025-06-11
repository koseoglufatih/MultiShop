using MediatR;
using MultiShop.Order.Applications.Features.CQRS.Commands.OrderDetailCommands;
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
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
    {
        private readonly IGenericRepository<Ordering> _genericRepository;

        public RemoveOrderingCommandHandler(IGenericRepository<Ordering> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
        {
            var values = await _genericRepository.GetByIdAsync(request.Id);
            await _genericRepository.DeleteAsync(values);

        }
    }
}
