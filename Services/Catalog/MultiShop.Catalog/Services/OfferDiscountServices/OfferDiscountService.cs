using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
	public class OfferDiscountService : IOfferDiscountService
	{
		private readonly IMapper _mapper;
		private readonly IMongoCollection<OfferDiscount> _offerDiscount;
		public OfferDiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_offerDiscount = database.GetCollection<OfferDiscount>(_databaseSettings.OfferDiscountCollectionName);
			_mapper = mapper;
		}

		public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
		{
			var values = _mapper.Map<OfferDiscount>(createOfferDiscountDto);
			await _offerDiscount.InsertOneAsync(values);
		}

		public async Task DeleteOfferDiscountAsync(string id)
		{
			await _offerDiscount.DeleteOneAsync(x => x.OfferDiscountId == id);
		}

		public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
		{
			var values = await _offerDiscount.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultOfferDiscountDto>>(values);
		}

		public async Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
		{
			var values = await _offerDiscount.Find<OfferDiscount>(x => x.OfferDiscountId == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdOfferDiscountDto>(values);
		}

		public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountlDto)
		{
			var values = _mapper.Map<OfferDiscount>(updateOfferDiscountlDto);
			await _offerDiscount.FindOneAndReplaceAsync(x => x.OfferDiscountId == updateOfferDiscountlDto.OfferDiscountId, values);
		}
	}
}
