using Shop.Application.Repositories.Interfaces;

namespace Shop.Application.Services.Implementations
{
	public class BaseService
	{
		protected readonly IUnitOfWork _unitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
