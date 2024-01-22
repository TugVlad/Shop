namespace Shop.Application.Repositories.Interfaces
{
	public interface IUnitOfWork
	{
		Task SaveChangesAsync();
		Task BeginTransactionAsync();
		Task CommitTransactionAsync();
		Task RollbackTransactionAsync();
	}
}
