using MultiShop.Order.Applications.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Applications.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Applications.Features.CQRS.Handlers.AddressHandlers
{
	public class RemoveAddressCommandHandler
	{
		private readonly IGenericRepository<Address> _repository;

		public RemoveAddressCommandHandler(IGenericRepository<Address> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveAddressCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			await _repository.DeleteAsync(value);
		}
	}
}
