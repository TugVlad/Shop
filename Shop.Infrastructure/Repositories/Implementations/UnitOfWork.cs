using Shop.Application.Repositories.Interfaces;
using Shop.Data;

namespace Shop.Infrastructure.Repositories.Implementations
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ShopContext _context;

		public UnitOfWork(ShopContext context)
		{
			_context = context;
		}

		public async Task BeginTransactionAsync()
		{
			await _context.Database.BeginTransactionAsync();
		}

		public async Task CommitTransactionAsync()
		{
			await _context.Database.CommitTransactionAsync();
		}

		public async Task RollbackTransactionAsync()
		{
			await _context.Database.RollbackTransactionAsync();
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
