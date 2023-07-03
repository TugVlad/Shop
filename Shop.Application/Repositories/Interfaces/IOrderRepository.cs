using Shop.Core.Models;

namespace Shop.Application.Repositories.Interfaces
{
	public interface IOrderRepository : IBaseRepository
	{
		Task<List<Order>> GetAllOrdersAsync();
		Task<Order> GetOrderByIdAsync(int id);
		Task<Order> GetOrderWithDependenciesByIdAsync(int id);
		Task<Order> AddOrderAsync(Order order);
		Task SaveChangesAsync();
	}
}
