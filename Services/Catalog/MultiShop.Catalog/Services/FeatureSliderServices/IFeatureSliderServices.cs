using MultiShop.Catalog.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
	public interface IFeatureSliderServices
	{
		Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
		Task CreateFeatureSliderAsync(CreateFeatureSliderDtos createFeatureSliderDtos);
		Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDtos);
		Task DeleteFeatureSliderAsync(string id);
		Task<GetByIdFeatureSliderDto> GetByIdtFeatureSliderAsync(string id);
		Task FeatureSliderChangeStatusToTrue(string id);
		Task FeatureSliderChangeStatusToFalse(string id);
	}
}
