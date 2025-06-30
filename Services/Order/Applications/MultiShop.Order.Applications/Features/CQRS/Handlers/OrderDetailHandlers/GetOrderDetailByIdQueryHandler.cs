using MultiShop.Order.Applications.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Applications.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Applications.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Applications.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class GetOrderDetailByIdQueryHandler
	{
		private readonly IGenericRepository<OrderDetail> _repository;

		public GetOrderDetailByIdQueryHandler(IGenericRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

		public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetOrderDetailByIdQueryResult
			{
				OrderDetailId = values.OrderDetailId,
				ProductAmount = values.ProductAmount,
				ProductId = values.ProductId,
				ProductName = values.ProductName,
				OrderingId = values.OrderingId,
				ProductPrice = values.ProductPrice,
				ProductTotalPrice = values.ProductTotalPrice
			};
		}
	}
}
