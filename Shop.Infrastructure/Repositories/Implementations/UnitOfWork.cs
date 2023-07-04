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

        public async Task BeginTransaction()
		{
			await _context.Database.BeginTransactionAsync();
		}

		public async Task CommitTransaction()
		{
			await _context.Database.CommitTransactionAsync();
		}

		public async Task RollbackTransaction()
		{
			await _context.Database.RollbackTransactionAsync();
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
