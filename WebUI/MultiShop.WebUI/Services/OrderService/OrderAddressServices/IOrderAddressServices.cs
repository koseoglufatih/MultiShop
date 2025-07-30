using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderService.OrderAddressServices
{
    public interface IOrderAddressServices
    {
        //Task<List<ResultOrderAddressDto>> GetAllOrderAddressAsync();
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);

        //Task UpdateOrderAddressAsync(UpdateOrderAddressDto updateAboutDto);
        //Task DeleteOrderAddressAsync(string id);
        //Task<UpdateOrderAddressDto> GetByIdAboutAsync(string id);
    }
}
