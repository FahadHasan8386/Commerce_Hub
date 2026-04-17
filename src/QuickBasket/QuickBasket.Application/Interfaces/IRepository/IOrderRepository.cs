using QuickBasket.Application.Features.Orders.DTOs;

namespace QuickBasket.Application.Interefaces.IRepository
{
    public interface IOrderRepository
    {
        Task<List<OrderResponseDto>> GetAllAsync();
        Task<OrderResponseDto?> GetByIdAsync(int id);
        Task<int> CreateOrderAsync(CreateOrderDto order);
        Task<int> UpdateOrderAsync(UpdateOrderDto order);
        Task<bool> DeleteOrderAsync(int id);
    }
}
