using MediatR;

namespace MultiShop.Order.Applications.Features.Mediator.Commands.OrderingCommands
{
    public class RemoveOrderingRequest :IRequest
    {
        public int Id { get; set; }

        public RemoveOrderingRequest(int id)
        {
            Id = id;
        }
    }
}
