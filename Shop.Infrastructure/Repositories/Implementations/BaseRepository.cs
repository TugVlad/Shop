using Shop.Data;

namespace Shop.Infrastructure.Repositories.Implementations
{
	public class BaseRepository
	{
		protected readonly ShopContext _context;

		protected BaseRepository(ShopContext context)
		{
			_context = context;
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
