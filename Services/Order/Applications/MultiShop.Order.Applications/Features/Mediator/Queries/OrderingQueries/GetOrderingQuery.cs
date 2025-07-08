using MediatR;
using MultiShop.Order.Applications.Features.Mediator.Results.OrderingResults;

namespace MultiShop.Order.Applications.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
    {

    }
}
