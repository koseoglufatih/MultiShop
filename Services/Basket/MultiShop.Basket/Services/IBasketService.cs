using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(string userId);
        Task<bool> SaveBasket(BasketTotalDto basket);
        Task<bool> DeleteBasket(string userId);

    }
}
