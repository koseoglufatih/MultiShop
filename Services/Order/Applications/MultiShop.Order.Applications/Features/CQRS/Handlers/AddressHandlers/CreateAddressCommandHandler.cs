using MultiShop.Order.Applications.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Applications.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Applications.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IGenericRepository<Address> _repository;

        public CreateAddressCommandHandler(IGenericRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressCommand.City,
                Detail1 = createAddressCommand.Detail1,
                District = createAddressCommand.District,
                UserId = createAddressCommand.UserId,
                Country = createAddressCommand.Country,
                Description = createAddressCommand.Description,
                Detail2 = createAddressCommand.Detail2,
                Email = createAddressCommand.Email,
                Name = createAddressCommand.Name,
                Phone = createAddressCommand.Phone,
                Surname = createAddressCommand.Surname,
                ZipCode = createAddressCommand.ZipCode
            });
        }
    }
}
