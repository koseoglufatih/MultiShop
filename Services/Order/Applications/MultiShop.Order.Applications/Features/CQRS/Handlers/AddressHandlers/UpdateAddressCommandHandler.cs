using MultiShop.Order.Applications.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Applications.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Applications.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IGenericRepository<Address> _genericRepository;

        public UpdateAddressCommandHandler(IGenericRepository<Address> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var values = await _genericRepository.GetByIdAsync(command.AddressId);
            values.Detail = command.Detail;
            values.District = command.District;
            values.City = command.City;
            values.UserId = command.UserId;
            await _genericRepository.UpdateAsync(values);
        }
    }
}
