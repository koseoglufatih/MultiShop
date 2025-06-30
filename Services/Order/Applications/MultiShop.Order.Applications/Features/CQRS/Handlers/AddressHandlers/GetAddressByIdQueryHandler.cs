using MultiShop.Order.Applications.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Applications.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Applications.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Applications.Features.CQRS.Handlers.AddressHandlers
{
	public class GetAddressByIdQueryHandler
	{
		private readonly IGenericRepository<Address> _repository;

		public GetAddressByIdQueryHandler(IGenericRepository<Address> repository)
		{
			_repository = repository;
		}

		public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetAddressByIdQueryResult
			{
				AddressId = values.AddressId,
				City = values.City,
				Detail = values.Detail,
				District = values.District,
				UserId = values.UserId
			};
		}
	}
}
