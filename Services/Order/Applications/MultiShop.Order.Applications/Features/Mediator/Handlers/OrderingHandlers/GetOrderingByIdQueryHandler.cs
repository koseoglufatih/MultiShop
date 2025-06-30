using MediatR;
using MultiShop.Order.Applications.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Applications.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Applications.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Applications.Features.Mediator.Handlers.OrderingHandlers
{
	public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
	{
		private readonly IGenericRepository<Ordering> _genericRepository;

		public GetOrderingByIdQueryHandler(IGenericRepository<Ordering> genericRepository)
		{
			_genericRepository = genericRepository;
		}

		public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _genericRepository.GetByIdAsync(request.Id);
			return new GetOrderingByIdQueryResult
			{
				OrderDate = values.OrderDate,
				OrderingId = values.OrderingId,
				TotalPrice = values.TotalPrice,
				UserId = values.UserId
			};

		}
	}
}

