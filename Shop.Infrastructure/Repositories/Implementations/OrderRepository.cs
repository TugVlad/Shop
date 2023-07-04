using Microsoft.EntityFrameworkCore;
using Shop.Application.Repositories.Interfaces;
using Shop.Core.Models;
using Shop.Data;

namespace Shop.Infrastructure.Repositories.Implementations
{
	public class OrderRepository : BaseRepository, IOrderRepository
	{
		public OrderRepository(ShopContext context) : base(context) { }

		public async Task<Order> AddOrderAsync(Order order)
		{
			await _context.Orders.AddAsync(order);
			await SaveChangesAsync();

			return order;
		}

		public Task<List<Order>> GetAllOrdersAsync()
		{
			return _context.Orders.ToListAsync();
		}

		public Task<Order> GetOrderByIdAsync(int id)
		{
			return _context.Orders.FirstOrDefaultAsync(e => e.Id == id);
		}

		public Task<Order> GetOrderWithDependenciesByIdAsync(int id)
		{
			return _context.Orders.Include(e => e.ProductOrders).ThenInclude(e => e.Product).FirstOrDefaultAsync(e => e.Id == id);
		}
	}
}
