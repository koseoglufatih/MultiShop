using MediatR;
using MultiShop.Order.Applications.Features.Mediator.Results.OrderingResults;

namespace MultiShop.Order.Applications.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResult>
    {
        public int Id { get; set; }

        public GetOrderingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
