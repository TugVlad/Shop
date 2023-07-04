namespace Shop.Application.Repositories.Interfaces
{
	public interface IUnitOfWork
	{
		Task SaveChangesAsync();
		Task BeginTransaction();
		Task CommitTransaction();
		Task RollbackTransaction();
	}
}
