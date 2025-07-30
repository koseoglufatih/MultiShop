using MultiShop.Order.Applications.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Applications.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Applications.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler

    {
        private readonly IGenericRepository<Address> _repository;

        public GetAddressQueryHandler(IGenericRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressByIdQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressByIdQueryResult
            {
                AddressId = x.AddressId,
                City = x.City,
                Detail = x.Detail1,
                District = x.District,
                UserId = x.UserId
            }).ToList();
        }
    }
}
