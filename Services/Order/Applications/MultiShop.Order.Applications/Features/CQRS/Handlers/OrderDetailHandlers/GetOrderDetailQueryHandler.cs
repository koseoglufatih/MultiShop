using MultiShop.Order.Applications.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Applications.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Applications.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class GetOrderDetailQueryHandler
	{
		private readonly IGenericRepository<OrderDetail> _repository;

		public GetOrderDetailQueryHandler(IGenericRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetOrderDetailByIdQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetOrderDetailByIdQueryResult
			{
				OrderDetailId = x.OrderDetailId,
				ProductAmount = x.ProductAmount,
				OrderingId = x.OrderingId,
				ProductId = x.ProductId,
				ProductName = x.ProductName,
				ProductPrice = x.ProductPrice,
				ProductTotalPrice = x.ProductTotalPrice
			}).ToList();
		}
	}
}
